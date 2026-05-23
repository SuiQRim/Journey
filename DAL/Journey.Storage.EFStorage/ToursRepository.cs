using Journey.Models;
using Journey.Storage.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Journey.Storage.EFStorage
{
    /// <summary>
    /// Репозиторий для взаимодействия с сущностью туров в базе данных
    /// </summary>
    public class ToursRepository : IToursRepository
    {
        private readonly JourneyContext context;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public ToursRepository(JourneyContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Tour>> GetToursAsync() => await context.Tours.ToArrayAsync();

        /// <inheritdoc/>
        public async Task<bool> AddTourAsync(Tour tour)
        {
            await context.Tours.AddAsync(tour);
            await context.SaveChangesAsync();

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateTourAsync(Tour tour)
        {
            var existingTour = await context.Tours.FindAsync(tour.Id);

            if (existingTour == null)
            {
                return false;
            }

            context.Entry(existingTour)
                .CurrentValues
                .SetValues(tour);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
