namespace Journey.Storage.Contracts
{
    /// <summary>
    /// Интерфейс записи данных в хранилище
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="entity">сущность</param>
        /// <returns>Успешность операции</returns>
        Task<bool> AddAsync<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Изменение сущности
        /// </summary>
        /// <param name="entity">сущность</param>
        /// <returns>Успешность операции</returns>
        bool Update<TEntity>(TEntity currentEntity, TEntity newEntity)
            where TEntity : class;

        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <param name="entity">сущность</param>
        /// <returns>Успешность операции</returns>
        bool Remove<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Сохранение изменений
        /// </summary>
        /// <returns>Кол-во измененных строк</returns>
        Task<int> SaveChangesAsync();
    }
}
