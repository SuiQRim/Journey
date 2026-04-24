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
        public void Constructor_ShouldInitializeDefaultTours_WhenNoParametersPassed()
        {
            // Arrange
            var repo = new ToursRepository();

            // Act
            var tours = repo.GetTours().ToList();

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
        public void GetTours_ShouldReturnAllAddedTours()
        {
            // Arrange
            var repo = new ToursRepository();
            var countBefore = repo.GetTours().Count();

            repo.AddTour(new Tour() { Location = "Италия" });
            repo.AddTour(new Tour() { Location = "Испания" });

            // Act
            var result = repo.GetTours();

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
        public void AddTour_ShouldAssignNextId_WhenRepositoryHasExistingData()
        {
            // Arrange
            var repo = new ToursRepository();
            var maxIdBefore = repo.GetTours().Max(x => x.Id);

            // Act
            repo.AddTour(new Tour());

            // Assert
            var added = repo.GetTours().Last();
            added.Id.Should().Be(maxIdBefore + 1);
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursRepository.AddTour(Tour)"/>
        /// что при добавлении нескольких туров им назначаются
        /// уникальные идентификаторы в возрастающем порядке.
        /// </summary>
        [Fact]
        public void AddTour_ShouldGenerateUniqueSequentialIds_WhenAddingMultipleTours()
        {
            // Arrange
            var repo = new ToursRepository();
            var countBefore = repo.GetTours().Count();

            // Act
            repo.AddTour(new Tour());
            repo.AddTour(new Tour());

            // Assert
            var ids = repo.GetTours().Select(x => x.Id);

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
        public void AddTour_ShouldAddTourWithAllFieldsAndReturnTrue()
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
            var result = repo.AddTour(tour);

            // Assert
            result.Should().BeTrue();

            var actual = repo.GetTours().Single(x => x.Id == tour.Id);

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
        public void UpdateTour_ShouldUpdateAllFields_WhenTourExists()
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

            repo.AddTour(original);

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
            var result = repo.UpdateTour(updated);

            // Assert
            result.Should().BeTrue();

            var actual = repo.GetTours().Single(x => x.Id == original.Id);

            actual.Should().BeEquivalentTo(updated, options =>
                options.Excluding(x => x.Id));
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursRepository.UpdateTour(Tour)"/>
        /// что метод UpdateTour возвращает значение false, если обновляемый тур не найден.
        /// </summary>
        [Fact]
        public void UpdateTour_ShouldReturnFalse_WhenTourNotFound()
        {
            // Arrange
            var repo = new ToursRepository();

            repo.AddTour(new Tour { Location = "Италия" });

            var toursBefore = repo.GetTours().ToList();

            // Act
            var result = repo.UpdateTour(new Tour { Id = 999 });

            // Assert
            result.Should().BeFalse();
            repo.GetTours().Should().BeEquivalentTo(toursBefore);
        }
    }
}
