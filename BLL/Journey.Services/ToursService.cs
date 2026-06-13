using Journey.Models;
using Journey.Services.Contracts;
using Journey.Storage.Contracts;

namespace Journey.Services
{
    /// <summary>
    /// Класс с функционалом для работы с турами
    /// </summary>
    public class ToursService : ITourService
    {
        private const int PageSize = 10;
        private readonly IToursRepository repository;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="repository">Класс для взаимодействия с хранилищем данных</param>
        public ToursService(IToursRepository repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Tour>> GetToursAsync() => await repository.GetToursAsync();

        /// <inheritdoc/>
        public async Task<PagedResult<Tour>> GetToursAsync(int page)
        {
            var items = await repository.GetPagedAsync(page, PageSize);
            var totalCount = await repository.CountAsync();

            return new PagedResult<Tour>
            {
                Items = items,
                Page = page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize)
            };
        }

        /// <inheritdoc/>
        public async Task<bool> AddTourAsync(Tour tour) => await repository.AddTourAsync(tour);

        /// <inheritdoc/>
        public async Task<bool> UpdateTourAsync(Tour tour) => await repository.UpdateTourAsync(tour);

        /// <inheritdoc/>
        public async Task<bool> RemoveTourAsync(int tourId) => await repository.RemoveTourAsync(tourId);

        /// <inheritdoc/>
        public async Task<TourStatistics> CalculateStatisticsAsync()
        {
            var tours = (await repository.GetToursAsync()).ToList();

            if (tours.Count == 0)
            {
                return new TourStatistics();
            }

            var total = tours.Count;

            return new TourStatistics
            {
                TotalTours = total,
                AvgVacationers = tours.Average(t => t.VacationerCount),
                WifiPercent = tours.Count(t => t.WiFiAvailabble) * 100.0 / total,
                AvgSurchargePercent = tours.Average(t =>
                {
                    var totalPrice = GetTotalPrice(t);

                    if (totalPrice == 0)
                    {
                        return 0;
                    }

                    return (double)t.Surcharge / (double)totalPrice * 100.0;
                }),
                MaxTourPrice = tours.Max(GetTotalPrice),
                AvgNights = tours.Average(t => t.NightCount),
                SurchargeShare = tours.Count(t => t.Surcharge > 0) * 100.0 / total
            };
        }

        /// <inheritdoc/>
        public decimal GetTotalPrice(Tour t)
        {
            return t.CostPerVacationer * t.VacationerCount * t.NightCount + t.Surcharge;
        }

        /// <inheritdoc/>
        public decimal GetPricePerNight(Tour tour)
        {
            if (tour.NightCount == 0)
            {
                return 0;
            }

            return GetTotalPrice(tour) / tour.NightCount;
        }

        /// <inheritdoc/>
        public decimal GetNormalizedPrice(IEnumerable<Tour> tours, Tour target)
        {
            var getPrice = GetTotalPrice;

            var prices = tours.Select(getPrice);

            var min = prices.Min();
            var max = prices.Max();

            var total = getPrice(target);

            return max == min
                ? 1m
                : (total - min) / (max - min);
        }
    }
}
