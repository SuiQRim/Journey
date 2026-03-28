using Journey.Models;

namespace Journey.Storage.Contracts
{
    /// <summary>
    /// Класс для взаимодействия с хранилищем туров
    /// </summary>
    public interface IToursRepository
    {
        /// <summary>
        /// Возвращает полный список всех туров
        /// </summary>
        IEnumerable<Tour> GetTours();
    }
}
