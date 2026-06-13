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
        Task<IEnumerable<Tour>> GetToursAsync();

        /// <summary>
        /// Добавление нового тура
        /// </summary>
        /// <param name="tour">тур который нужно добавить</param>
        /// <returns>Успешность</returns>
        Task<bool> AddTourAsync(Tour tour);

        /// <summary>
        /// Редактирование существующего тура
        /// </summary>
        /// <param name="tour">тур с обновленными данными</param>
        /// <returns>Успешность</returns>
        Task<bool> UpdateTourAsync(Tour tour);

        /// <summary>
        /// Удаление тура по его идентификатору
        /// </summary>
        /// <param name="tourId">Идентификатор тура</param>
        /// <returns>Успешность</returns>
        Task<bool> RemoveTourAsync(int tourId);

        /// <summary>
        /// Метод считает агрегированную статистику по списку туров
        /// </summary>
        /// <param name="tours">список туров</param>
        /// <returns>Статистика</returns>
        TourStatistics CalculateStatistics(IEnumerable<Tour> tours);

        /// <summary>
        /// Считает итоговую цену тура
        /// </summary>
        /// <param name="tour">тур который нужно посчитать</param>
        decimal GetTotalPrice(Tour tour);

        /// <summary>
        /// Находит цену за ночь для тура
        /// </summary>
        /// <param name="tour">тур</param>
        /// <returns>цена за ночь</returns>
        decimal GetPricePerNight(Tour tour);

        /// <summary>
        /// Вычисляет цену тура от 0 до 1 относительно других туров
        /// </summary>
        /// <param name="tours">список туров</param>
        /// <param name="target">тур которому нужно найти множитель</param>
        /// <returns>множитель тура</returns>
        decimal GetNormalizedPrice(IEnumerable<Tour> tours, Tour target);
    }
}
