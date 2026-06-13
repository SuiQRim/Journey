using Journey.Models;

namespace Journey.WebAppMVC.Models
{
    /// <summary>
    /// ViewModel для отображения коллекции туров с пагинацией и статистикой
    /// </summary>
    public class ToursCollectionViewModel
    {
        /// <summary>
        /// Коллекция туров для отображения на странице, с учетом пагинации
        /// </summary>
        public required IEnumerable<Tour> Tours { get; set; }

        /// <summary>
        /// Статистика по коллекции туров
        /// </summary>
        public required TourStatistics Statistics { get; set; }

        /// <summary>
        /// Номер текущей страницы
        /// </summary>
        public required int Page { get; set; }

        /// <summary>
        /// Общее количество страниц для пагинации
        /// </summary>
        public int TotalPages { get; set; }
    }
}
