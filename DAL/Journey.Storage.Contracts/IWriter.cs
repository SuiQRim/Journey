namespace Journey.Storage.Contracts
{
    /// <summary>
    /// Интерфейс записи данных в хранилище
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Добавление сущности в хранилище
        /// </summary>
        /// <typeparam name="TEntity">Сущность</typeparam>
        /// <param name="entity">Сущность для добавления</param>
        /// <returns>Результат операции добавления</returns>
        Task<bool> AddAsync<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <typeparam name="TEntity">Сущность</typeparam>
        /// <param name="entity">Сущность для обновления</param>
        /// <returns>Результат операции обновления</returns>
        Task<bool> UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <typeparam name="TEntity">Сущность</typeparam>
        /// <param name="entity">Сущность для удаления</param>
        /// <returns>Результат операции удаления</returns>
        Task<bool> RemoveAsync<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Сохранение изменений
        /// </summary>
        /// <returns>Кол-во измененных строк</returns>
        Task<int> SaveChangesAsync();
    }
}
