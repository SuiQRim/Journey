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
    }
}
