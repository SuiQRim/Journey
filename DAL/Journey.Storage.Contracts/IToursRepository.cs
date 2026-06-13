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
        Task<IEnumerable<Tour>> GetToursAsync();

        /// <summary>
        /// Добавляет новый тур в хранилище
        /// </summary>
        /// <param name="tour">новый тур</param>
        /// <returns>Успешность</returns>
        Task<bool> AddTourAsync(Tour tour);

        /// <summary>
        /// Редактирует существующий тур
        /// </summary>
        /// <param name="tour">тур с обновленными данными</param>
        /// <returns>Успешность</returns>
        Task<bool> UpdateTourAsync(Tour tour);

        /// <summary>
        /// Удаляет тур по его идентификатору
        /// </summary>
        /// <param name="tourId">идентификатор тура</param>
        /// <returns>Успешность</returns>
        Task<bool> RemoveTourAsync(int tourId);
    }
}
