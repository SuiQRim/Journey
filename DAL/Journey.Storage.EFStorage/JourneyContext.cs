using Journey.Models;
using Microsoft.EntityFrameworkCore;

namespace Journey.Storage.EFStorage
{
    /// <summary>
    /// Контекст базы данных для приложения Journey, использующий Entity Framework Core для взаимодействия с базой данных SQL Server.
    /// </summary>
    public class JourneyContext : DbContext
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
    }
}
