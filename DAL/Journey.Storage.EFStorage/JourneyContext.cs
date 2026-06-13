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

        public JourneyContext(DbContextOptions<JourneyContext> options)
            : base(options)
        { }

        public IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>()
                .AsNoTracking()
                .AsQueryable();
        }

        public async Task<bool> AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            await base.Set<TEntity>().AddAsync(entity);
            return true;
        }

        public bool Update<TEntity>(TEntity entity)
            where TEntity : class
        {
            Set<TEntity>().Update(entity);

            return true;
        }

        public bool Remove<TEntity>(TEntity entity)
            where TEntity : class
        {
            Set<TEntity>().Remove(entity);
            return true;
        }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
    }
}
