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
        private readonly IReader reader;
        private readonly IWriter writer;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        public ToursRepository(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Tour>> GetToursAsync() => await reader.GetAll<Tour>().ToArrayAsync();

        /// <inheritdoc/>
        public async Task<bool> AddTourAsync(Tour tour)
        {
            await writer.AddAsync(tour);
            await writer.SaveChangesAsync();

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateTourAsync(Tour tour)
        {
            var existingTour = await reader.GetAll<Tour>().FirstOrDefaultAsync(t => t.Id == tour.Id);

            if (existingTour == null)
            {
                return false;
            }

            writer.Update(tour);

            await writer.SaveChangesAsync();

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> RemoveTourAsync(int tourId)
        {
            var tour = await reader.GetAll<Tour>().FirstOrDefaultAsync(t => t.Id == tourId);

            if (tour == null)
            {
                return false;
            }

            writer.Remove(tour);
            await writer.SaveChangesAsync();

            return true;
        }
    }
}
