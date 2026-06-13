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
        /// Получает список туров для указанной страницы и размера страницы (для пагинации)
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="pageSize">размер страницы</param>
        /// <returns>Список туров для указанной страницы</returns>
        Task<IEnumerable<Tour>> GetPagedAsync(int page, int pageSize);

        /// <summary>
        /// Возвращает количество всех туров
        /// </summary>
        /// <returns>Количество туров</returns>
        Task<int> CountAsync();

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
