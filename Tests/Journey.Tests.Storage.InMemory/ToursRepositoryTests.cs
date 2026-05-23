using FluentAssertions;
using Journey.Models;
using Journey.Storage.InMemory;

namespace Journey.Tests.Storage.InMemory
{
    /// <summary>
    /// Класс тестов проверяющих <see cref="ToursRepository"/>
    /// </summary>
    public class ToursRepositoryTests
    {
        /// <summary>
        /// Проверяет, что конструктор <see cref="ToursRepository()"/>,
        /// Инициализирует коллекцию туров стандартными данными,
        /// и все идентификаторы уникальны и упорядочены по возрастанию.
        /// </summary>
        [Fact]
        public async Task Constructor_ShouldInitializeDefaultTours_WhenNoParametersPassed()
        {
            // Arrange
            var repo = new ToursRepository();

            // Act
            var tours = (await repo.GetToursAsync()).ToList();

            // Assert
            tours.Should().NotBeNullOrEmpty();
            tours.Select(x => x.Id)
                 .Should()
                 .OnlyHaveUniqueItems()
                 .And.BeInAscendingOrder();
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursRepository.GetTours()"/>,
        /// что метод GetTours возвращает все добавленные туры,
        /// включая ранее существующие и добавленные в процессе теста.
        /// </summary>
        [Fact]
        public async Task GetTours_ShouldReturnAllAddedTours()
        {
            // Arrange
            var repo = new ToursRepository();
            var countBefore = (await repo.GetToursAsync()).Count();

            await repo.AddTourAsync(new Tour() { Location = "Италия" });
            await repo.AddTourAsync(new Tour() { Location = "Испания" });

            // Act
            var result = await repo.GetToursAsync();

            // Assert
            result.Should().HaveCount(countBefore + 2)
                .And.Contain(x => x.Location == "Италия")
                .And.Contain(x => x.Location == "Испания");
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursRepository.AddTour(Tour)"/>,
        /// что при добавлении нового тура идентификатор назначается
        /// как следующий после максимального существующего.
        /// </summary>
        [Fact]
        public async Task AddTour_ShouldAssignNextId_WhenRepositoryHasExistingData()
        {
            // Arrange
            var repo = new ToursRepository();
            var maxIdBefore = (await repo.GetToursAsync()).Max(x => x.Id);

            // Act
            await repo.AddTourAsync(new Tour());

            // Assert
            var added = (await repo.GetToursAsync()).Last();
            added.Id.Should().Be(maxIdBefore + 1);
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursRepository.AddTour(Tour)"/>
        /// что при добавлении нескольких туров им назначаются
        /// уникальные идентификаторы в возрастающем порядке.
        /// </summary>
        [Fact]
        public async Task AddTour_ShouldGenerateUniqueSequentialIds_WhenAddingMultipleTours()
        {
            // Arrange
            var repo = new ToursRepository();
            var countBefore = (await repo.GetToursAsync()).Count();

            // Act
            await repo.AddTourAsync(new Tour());
            await repo.AddTourAsync(new Tour());

            // Assert
            var ids = (await repo.GetToursAsync()).Select(x => x.Id);

            ids.Should()
               .HaveCount(countBefore + 2)
               .And.OnlyHaveUniqueItems()
               .And.BeInAscendingOrder();
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursRepository.AddTour(Tour)"/>
        /// что метод AddTour успешно добавляет тур в репозиторий
        /// и возвращает true.
        /// </summary>
        [Fact]
        public async Task AddTour_ShouldAddTourWithAllFieldsAndReturnTrue()
        {
            // Arrange
            var repo = new ToursRepository();

            var tour = new Tour
            {
                Location = "Италия",
                NightCount = 7,
                DepartureDate = DateTime.UtcNow,
                CostPerVacationer = 50000,
                VacationerCount = 2,
                WiFiAvailabble = true,
                Surcharge = 1234.56m
            };

            var expected = new Tour
            {
                Location = tour.Location,
                NightCount = tour.NightCount,
                DepartureDate = tour.DepartureDate,
                CostPerVacationer = tour.CostPerVacationer,
                VacationerCount = tour.VacationerCount,
                WiFiAvailabble = tour.WiFiAvailabble,
                Surcharge = tour.Surcharge
            };

            // Act
            var result = await repo.AddTourAsync(tour);

            // Assert
            result.Should().BeTrue();

            var actual = (await repo.GetToursAsync()).Single(x => x.Id == tour.Id);

            actual.Should().BeEquivalentTo(expected, options =>
                options.Excluding(x => x.Id));

            actual.Id.Should().BeGreaterThan(0);
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursRepository.UpdateTour(Tour)"/>
        /// что метод обновления тура корректно изменяет все поля существующего тура.
        /// </summary>
        /// <remarks>Этот тест гарантирует, что при обновлении существующего тура все его свойства
        /// заменяются на новые значения, а идентификатор тура остается неизменным</remarks>
        [Fact]
        public async Task UpdateTour_ShouldUpdateAllFields_WhenTourExists()
        {
            // Arrange
            var repo = new ToursRepository();

            var original = new Tour
            {
                Location = "Италия",
                NightCount = 10,
                DepartureDate = DateTime.UtcNow.AddDays(-5),
                CostPerVacationer = 50000,
                VacationerCount = 3,
                WiFiAvailabble = false,
                Surcharge = 1000m
            };

            await repo.AddTourAsync(original);

            var updated = new Tour
            {
                Id = original.Id,
                Location = "Испания",
                NightCount = 20,
                DepartureDate = DateTime.UtcNow,
                CostPerVacationer = 89000,
                VacationerCount = 5,
                WiFiAvailabble = true,
                Surcharge = 3450.90m
            };

            // Act
            var result = await repo.UpdateTourAsync(updated);

            // Assert
            result.Should().BeTrue();

            var actual = (await repo.GetToursAsync()).Single(x => x.Id == original.Id);

            actual.Should().BeEquivalentTo(updated, options =>
                options.Excluding(x => x.Id));
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursRepository.UpdateTour(Tour)"/>
        /// что метод UpdateTour возвращает значение false, если обновляемый тур не найден.
        /// </summary>
        [Fact]
        public async Task UpdateTour_ShouldReturnFalse_WhenTourNotFound()
        {
            // Arrange
            var repo = new ToursRepository();

            await repo.AddTourAsync(new Tour { Location = "Италия" });

            var toursBefore = (await repo.GetToursAsync()).ToList();

            // Act
            var result = await repo.UpdateTourAsync(new Tour { Id = 999 });

            // Assert
            result.Should().BeFalse();
            (await repo.GetToursAsync()).Should().BeEquivalentTo(toursBefore);
        }
    }
}
