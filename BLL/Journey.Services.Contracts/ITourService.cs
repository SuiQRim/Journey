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
