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
        /// <returns>Успешность</returns>
        bool AddTour(Tour tour);

        /// <summary>
        /// Редактирует существующий тур
        /// </summary>
        /// <param name="tour">тур с обновленными данными</param>
        /// <returns>Успешность</returns>
        bool UpdateTour(Tour tour);
    }
}
