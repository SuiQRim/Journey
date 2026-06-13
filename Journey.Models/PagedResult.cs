namespace Journey.Models
{
    /// <summary>
    /// Класс для представления результата пагинации,
    /// содержащий коллекцию элементов на странице и информацию о пагинации
    /// </summary>
    /// <typeparam name="T">Тип объекта в коллекции</typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// Коллекция элементов на странице
        /// </summary>
        public required IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Номер текущей страницы
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Общее количество страниц для пагинации
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Общее количество элементов в коллекции (без учета пагинации)
        /// </summary>
        public int TotalCount { get; set; }
    }
}
