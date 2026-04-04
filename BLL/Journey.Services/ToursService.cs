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
        public IEnumerable<Tour> GetTours() => repository.GetTours();

        /// <inheritdoc/>
        public bool AddTour(Tour tour) => repository.AddTour(tour);

        /// <inheritdoc/>
        public bool UpdateTour(Tour tour) => repository.UpdateTour(tour);

        /// <inheritdoc/>
        public TourStatistics CalculateStatistics(IEnumerable<Tour> tours)
        {
            var list = tours.ToList();

            if (list.Count == 0)
            {
                return new TourStatistics();
            }

            return new TourStatistics
            {
                AvgVacationers = list.Average(t => t.VacationerCount),
                WifiPercent = list.Count(t => t.WiFiAvailabble) * 100.0 / list.Count,
                AvgSurchargePercent = list.Average(t =>
                {
                    var total = GetTotalPrice(t);
                    return total == 0 ? 0 : (double)(t.Surcharge / total) * 100.0;
                }),
                TotalTours = list.Count,
                MaxTourPrice = list.Max(GetTotalPrice),
                AvgNights = list.Average(t => t.NightCount),
                SurchargeShare = list.Count(t => t.Surcharge > 0) * 100.0 / list.Count
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
