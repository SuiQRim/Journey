using Journey.Models;

namespace Journey.Services.Contracts
{
    /// <summary>
    /// Интерфейс описывающий функционал для работы с турами
    /// </summary>
    public interface ITourService
    {
        /// <summary>
        /// Получение полного списка туров
        /// </summary>
        IEnumerable<Tour> GetTours();

        /// <summary>
        /// Добавление нового тура
        /// </summary>
        /// <param name="tour">тур который нужно добавить</param>
        /// <returns>Успешность</returns>
        bool AddTour(Tour tour);

        /// <summary>
        /// Редактирование существующего тура
        /// </summary>
        /// <param name="tour">тур с обновленными данными</param>
        /// <returns>Успешность</returns>
        bool UpdateTour(Tour tour);
    }
}
