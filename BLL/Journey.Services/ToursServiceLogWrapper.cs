using System.Diagnostics;
using Journey.Models;
using Journey.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Journey.Services
{
    /// <inheritdoc/>
    public class ToursServiceLogWrapper : ITourService
    {
        private readonly ITourService tourService;
        private readonly ILogger<ToursServiceLogWrapper> logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="tourService">сервис тура</param>
        /// <param name="logger">логгер</param>
        public ToursServiceLogWrapper(ITourService tourService, ILogger<ToursServiceLogWrapper> logger)
        {
            this.tourService = tourService;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Tour>> GetToursAsync()
        {
            var watcher = Stopwatch.StartNew();

            var tours = await tourService.GetToursAsync();

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Количество туров: {count}",
                nameof(GetToursAsync),
                msTime,
                tours.Count());

            return tours;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateTourAsync(Tour tour)
        {
            var watcher = Stopwatch.StartNew();

            var result = await tourService.UpdateTourAsync(tour);

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Количество туров: {count}",
                nameof(UpdateTourAsync),
                msTime,
                result);

            return result;
        }

        /// <inheritdoc/>
        public async Task<bool> AddTourAsync(Tour tour)
        {
            var watcher = Stopwatch.StartNew();

            var result = await tourService.AddTourAsync(tour);

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Результат выполнения {result}",
                nameof(AddTourAsync),
                msTime,
                result);

            return result;
        }

        /// <inheritdoc/>
        public TourStatistics CalculateStatistics(IEnumerable<Tour> tours)
        {
            var watcher = Stopwatch.StartNew();

            var result = tourService.CalculateStatistics(tours);

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Результат выполнения {@result}",
                nameof(CalculateStatistics),
                msTime,
                result);

            return result;
        }

        /// <inheritdoc/>
        public decimal GetNormalizedPrice(IEnumerable<Tour> tours, Tour target)
        {
            var watcher = Stopwatch.StartNew();

            var result = tourService.GetNormalizedPrice(tours, target);

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Результат выполнения {result}",
                nameof(GetNormalizedPrice),
                msTime,
                result);

            return result;
        }

        /// <inheritdoc/>
        public decimal GetPricePerNight(Tour tour)
        {
            var watcher = Stopwatch.StartNew();

            var result = tourService.GetPricePerNight(tour);

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Результат выполнения {result}",
                nameof(GetPricePerNight),
                msTime,
                result);

            return result;
        }

        /// <inheritdoc/>
        public decimal GetTotalPrice(Tour tour)
        {
            var watcher = Stopwatch.StartNew();

            var result = tourService.GetTotalPrice(tour);

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Результат выполнения {result}",
                nameof(GetTotalPrice),
                msTime,
                result);

            return result;
        }
    }
}
