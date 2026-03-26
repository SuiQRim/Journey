using Journey.Models;

namespace Journey.Storage
{
    public class ToursStorage
    {
        public List<Tour> Tours { get; private set; }

        public ToursStorage()
        {
            FillTours();
        }

        private void FillTours()
        {
            Tours =
            [
                new() {
                    Id = 1,
                    Location = "Турция",
                    NightCount = 7,
                    DepartureDate = DateTime.Parse("2024-06-15"),
                    CostPerVacationer = 45000,
                    VacotionerCount = 2,
                    WiFiAvailabble = 1,
                    Surcharge = 1500.50m
                },
                new() {
                    Id = 2,
                    Location = "Египет",
                    NightCount = 10,
                    DepartureDate = DateTime.Parse("2024-07-20"),
                    CostPerVacationer = 62000,
                    VacotionerCount = 3,
                    WiFiAvailabble = 1,
                    Surcharge = 2300.75m
                },
                new() {
                    Id = 3,
                    Location = "Сочи",
                    NightCount = 5,
                    DepartureDate = DateTime.Parse("2024-08-05"),
                    CostPerVacationer = 28000,
                    VacotionerCount = 1,
                    WiFiAvailabble = 1,
                    Surcharge = 0m
                },
                new() {
                    Id = 4,
                    Location = "Абхазия",
                    NightCount = 8,
                    DepartureDate = DateTime.Parse("2024-09-10"),
                    CostPerVacationer = 35000,
                    VacotionerCount = 4,
                    WiFiAvailabble = 0,
                    Surcharge = 800.25m
                },
                new() {
                    Id = 5,
                    Location = "ОАЭ",
                    NightCount = 14,
                    DepartureDate = DateTime.Parse("2024-10-01"),
                    CostPerVacationer = 89000,
                    VacotionerCount = 2,
                    WiFiAvailabble = 1,
                    Surcharge = 3450.90m
                }
            ];
        }
    }
}
