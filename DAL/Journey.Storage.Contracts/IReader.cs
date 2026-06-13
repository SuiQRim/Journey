namespace Journey.Storage.Contracts
{
    /// <summary>
    /// Интерфейс чтения данных из хранилища
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Получить список
        /// </summary>
        /// <typeparam name="TEntity">Сущность</typeparam>
        /// <returns>Описание запроса к сущности</returns>
        IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : class;
    }
}
