using System.Diagnostics;
using Journey.Models;
using Journey.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Journey.Services
{
    /// <inheritdoc/>
    public class ToursServiceLogWrapper : ITourService
    {
        private readonly ILogger logger;
        private readonly ITourService tourService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="tourService">сервис тура</param>
        /// <param name="logger">логгер</param>
        public ToursServiceLogWrapper(ITourService tourService, ILogger logger)
        {
            this.tourService = tourService;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public IEnumerable<Tour> GetTours()
        {
            var watcher = Stopwatch.StartNew();

            var tours = tourService.GetTours();

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Количество туров: {count}", nameof(GetTours), msTime, tours.Count());

            return tours;
        }

        /// <inheritdoc/>
        public bool UpdateTour(Tour tour)
        {
            var watcher = Stopwatch.StartNew();

            var result = tourService.UpdateTour(tour);

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Количество туров: {count}", nameof(UpdateTour), msTime, result);

            return result;
        }

        /// <inheritdoc/>
        public bool AddTour(Tour tour)
        {
            var watcher = Stopwatch.StartNew();

            var result = tourService.AddTour(tour);

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Результат выполнения {result}", nameof(AddTour), msTime, result);

            return result;
        }

        /// <inheritdoc/>
        public TourStatistics CalculateStatistics(IEnumerable<Tour> tours)
        {
            var watcher = Stopwatch.StartNew();

            var result = tourService.CalculateStatistics(tours);

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Результат выполнения {result}", nameof(CalculateStatistics), msTime, @result);

            return result;
        }

        /// <inheritdoc/>
        public decimal GetNormalizedPrice(IEnumerable<Tour> tours, Tour target)
        {
            var watcher = Stopwatch.StartNew();

            var result = tourService.GetNormalizedPrice(tours, target);

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Результат выполнения {result}", nameof(GetNormalizedPrice), msTime, @result);

            return result;
        }

        /// <inheritdoc/>
        public decimal GetPricePerNight(Tour tour)
        {
            var watcher = Stopwatch.StartNew();

            var result = tourService.GetPricePerNight(tour);

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Результат выполнения {result}", nameof(GetPricePerNight), msTime, @result);

            return result;
        }

        /// <inheritdoc/>
        public decimal GetTotalPrice(Tour tour)
        {
            var watcher = Stopwatch.StartNew();

            var result = tourService.GetTotalPrice(tour);

            watcher.Stop();
            var msTime = watcher.ElapsedMilliseconds;
            logger.LogDebug("Выполнение {метода}. Время выполнения заняло {ms} ms. Результат выполнения {result}", nameof(GetTotalPrice), msTime, @result);

            return result;
        }
    }
}
