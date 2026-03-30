using Journey.Models;
using Journey.Storage.Contracts;

namespace Journey.Storage.InMemory
{
    /// <summary>
    /// Класс для взаимодейтсвия с хранилищем сущности тура
    /// </summary>
    public class ToursRepository : IToursRepository
    {
        private readonly List<Tour> tours;
        private int idCouner;

        /// <summary>
        /// ctor
        /// </summary>
        public ToursRepository()
        {
            tours = GenerateTours();
            idCouner = tours.Max(t => t.Id) + 1;
        }

        /// <inheritdoc/>
        public IEnumerable<Tour> GetTours() => tours;

        /// <inheritdoc/>
        public bool AddTour(Tour tour)
        {
            tour.Id = idCouner++;
            tours.Add(tour);
            return true;
        }

        /// <inheritdoc/>
        public bool UpdateTour(Tour tour)
        {
            var existing = tours.FirstOrDefault(x => x.Id == tour.Id);

            if (existing is null)
            {
                return false;
            }

            existing.Location = tour.Location;
            existing.DepartureDate = tour.DepartureDate;
            existing.VacotionerCount = tour.VacotionerCount;
            existing.WiFiAvailabble = tour.WiFiAvailabble;
            existing.NightCount = tour.NightCount;
            existing.CostPerVacationer = tour.CostPerVacationer;
            existing.Surcharge = tour.Surcharge;

            return true;
        }

        private static List<Tour> GenerateTours()
        {
            return
            [
                new() {
                    Id = 1,
                    Location = "Турция",
                    NightCount = 7,
                    DepartureDate = DateTime.Parse("2024-06-15"),
                    CostPerVacationer = 45000,
                    VacotionerCount = 2,
                    WiFiAvailabble = true,
                    Surcharge = 1500.50m
                },
                new() {
                    Id = 2,
                    Location = "Египет",
                    NightCount = 10,
                    DepartureDate = DateTime.Parse("2024-07-20"),
                    CostPerVacationer = 62000,
                    VacotionerCount = 3,
                    WiFiAvailabble = false,
                    Surcharge = 2300.75m
                },
                new() {
                    Id = 3,
                    Location = "Сочи",
                    NightCount = 5,
                    DepartureDate = DateTime.Parse("2024-08-05"),
                    CostPerVacationer = 28000,
                    VacotionerCount = 1,
                    WiFiAvailabble = true,
                    Surcharge = 0m
                },
                new() {
                    Id = 4,
                    Location = "Абхазия",
                    NightCount = 8,
                    DepartureDate = DateTime.Parse("2024-09-10"),
                    CostPerVacationer = 35000,
                    VacotionerCount = 4,
                    WiFiAvailabble = false,
                    Surcharge = 800.25m
                },
                new() {
                    Id = 5,
                    Location = "ОАЭ",
                    NightCount = 14,
                    DepartureDate = DateTime.Parse("2024-10-01"),
                    CostPerVacationer = 89000,
                    VacotionerCount = 2,
                    WiFiAvailabble = true,
                    Surcharge = 3450.90m
                }
            ];
        }
    }
}
