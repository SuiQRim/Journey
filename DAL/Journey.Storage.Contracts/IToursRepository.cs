using Journey.Models;

namespace Journey.Storage.Contracts
{
    /// <summary>
    /// Интерфейс для взаимодействия с хранилищем туров
    /// </summary>
    public interface IToursRepository
    {
        /// <summary>
        /// Возвращает полный список всех туров
        /// </summary>
        IEnumerable<Tour> GetTours();

        /// <summary>
        /// Добавляет новый тур в хранилище
        /// </summary>
        /// <param name="tour">новый тур</param>
        /// <returns>флаг успешности добавления</returns>
        bool AddTour(Tour tour);
    }
}
