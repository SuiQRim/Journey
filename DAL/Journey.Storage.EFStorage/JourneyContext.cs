using Journey.Models;
using Journey.Storage.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Journey.Storage.EFStorage
{
    /// <summary>
    /// Контекст базы данных для приложения Journey, использующий Entity Framework Core для взаимодействия с базой данных SQL Server.
    /// </summary>
    public class JourneyContext : DbContext, IWriter, IReader
    {
        /// <summary>
        /// Таблица сущности тура
        /// </summary>
        public DbSet<Tour> Tours => Set<Tour>();

        /// <summary>
        /// Конструктор, который гарантирует создание базы данных при первом обращении к контексту
        /// </summary>
        public JourneyContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JourneyDB;Integrated Security=True;Connect Timeout=30;" +
                "Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }

        /// <summary>
        /// ctor для внедрения зависимостей
        /// </summary>
        /// <param name="options">Опции конфигурации контекста базы данных</param>
        public JourneyContext(DbContextOptions<JourneyContext> options)
            : base(options)
        { }

        /// <inheritdoc/>
        public IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>()
                .AsNoTracking()
                .AsQueryable();
        }

        /// <inheritdoc/>
        public async Task<bool> AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            await base.Set<TEntity>().AddAsync(entity);
            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            var key = Entry(entity).Property("Id").CurrentValue;

            var existing = await Set<TEntity>().FindAsync(key);

            if (existing == null)
            {
                return false;
            }

            Entry(existing).CurrentValues.SetValues(entity);

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> RemoveAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            var key = Entry(entity).Property("Id").CurrentValue;

            var tracked = await Set<TEntity>().FindAsync(key);

            if (tracked == null)
            {
                return false;
            }

            Set<TEntity>().Remove(tracked);

            return true;
        }

        /// <inheritdoc/>
        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
    }
}
