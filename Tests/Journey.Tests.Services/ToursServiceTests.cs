using FluentAssertions;
using Journey.Models;
using Journey.Services;
using Journey.Storage.Contracts;
using Moq;

namespace Journey.Tests.Services
{
    /// <summary>
    /// Класс тестов проверяющих <see cref="ToursService"/>
    /// </summary>
    public class ToursServiceTests
    {
        private readonly ToursService serviceWithEmptyRepositoryMock;
        public ToursServiceTests()
        {
            var mockRep = new Mock<IToursRepository>();
            serviceWithEmptyRepositoryMock = new ToursService(mockRep.Object);
        }

        /// <summary>
        /// Проверяет, что метод <see cref="ToursService.AddTour(Tour)"/>\
        /// вызывает метод репозитория и возвращает его результат.
        /// </summary>
        /// <param name="repoResult">результат выполнения метода репозитория</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void AddTour_ShouldCallRepository_AndReturnResult(bool repoResult)
        {
            // Arrange
            var mockRep = new Mock<IToursRepository>();
            var tour = new Tour { Location = "Италия" };
            mockRep.Setup(r => r.AddTour(tour))
                   .Returns(repoResult);

            var service = new ToursService(mockRep.Object);

            // Act
            var result = service.AddTour(tour);

            // Assert
            result.Should().Be(repoResult);
            mockRep.Verify(r => r.AddTour(tour), Times.Once);
        }


        /// <summary>
        /// Проверяет <see cref="ToursService.GetTours()"/>
        /// что метод вызывает соответствующий метод репозитория и возвращает ожидаемый список
        /// туров.
        /// </summary>
        [Fact]
        public void GetTours_ShouldCallRepository_AndReturnTours()
        {
            // Arrange
            var expected = new List<Tour>
            {
                new() { Id = 1, Location = "Италия" },
                new() { Id = 2, Location = "Испания" }
            };

            var mockRep = new Mock<IToursRepository>();
            mockRep.Setup(r => r.GetTours())
                   .Returns(expected);

            var service = new ToursService(mockRep.Object);

            // Act
            var result = service.GetTours();

            // Assert
            result.Should().BeEquivalentTo(expected);
            mockRep.Verify(r => r.GetTours(), Times.Once);
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursService.UpdateTour(Tour)"/>
        /// что он вызывает метод репозитория и возвращает его результат.
        /// </summary>
        /// <param name="repoResult">Результат выполнения метода репозитория</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void UpdateTour_ShouldCallRepository_AndReturnResult(bool repoResult)
        {
            // Arrange
            var mockRep = new Mock<IToursRepository>();
            var tour = new Tour { Id = 1, Location = "Италия" };
            mockRep.Setup(r => r.UpdateTour(tour))
                   .Returns(repoResult);

            var service = new ToursService(mockRep.Object);

            // Act
            var result = service.UpdateTour(tour);

            // Assert
            result.Should().Be(repoResult);
            mockRep.Verify(r => r.UpdateTour(tour), Times.Once);
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursService.CalculateStatistics(IEnumerable{Tour})"/>
        /// на правильность вычислений статистики по заданному списку туров
        /// </summary>
        [Fact]
        public void CalculateStatistics_ShouldReturnCorrectStatistics()
        {
            // Arrange
            var tours = CreateStatisticsTours();

            // Act
            var stats = serviceWithEmptyRepositoryMock.CalculateStatistics(tours);

            // Assert
            stats.TotalTours.Should().Be(3);
            stats.MaxTourPrice.Should().Be(20000);
            stats.AvgVacationers.Should().Be(3);
            stats.WifiPercent.Should().BeApproximately(66.67, 0.01);
            stats.AvgSurchargePercent.Should().BeApproximately(2.24, 0.01);
            stats.AvgNights.Should().BeApproximately(5.67, 0.01);
            stats.SurchargeShare.Should().BeApproximately(66.67, 0.01);
        }

        private static List<Tour> CreateStatisticsTours()
        {
            return [

                new()
                {
                    Id = 1,
                    Location = "Италия",
                    VacationerCount = 2,
                    WiFiAvailabble = true,
                    Surcharge = 100,
                    CostPerVacationer = 500,
                    NightCount = 2
                },
                new()
                {
                    Id = 2,
                    Location = "Испания",
                    VacationerCount = 5,
                    WiFiAvailabble = false,
                    Surcharge = 0,
                    CostPerVacationer = 400,
                    NightCount = 10
                },
                new()
                {
                    Id = 3,
                    Location = "Греция",
                    VacationerCount = 2,
                    WiFiAvailabble = true,
                    Surcharge = 200,
                    CostPerVacationer = 1000,
                    NightCount = 5
                }
            ];
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursService.CalculateStatistics(IEnumerable{Tour})"/>
        /// на корректную обработку пустого списка туров (защита от деления на 0)
        /// </summary>
        [Fact]
        public void CalculateStatistics_ShouldReturnDefaultStatistics_WhenToursListIsEmpty()
        {
            // Arrange
            var tours = new List<Tour>();

            // Act
            var stats = serviceWithEmptyRepositoryMock.CalculateStatistics(tours);

            // Assert
            stats.TotalTours.Should().Be(0);
            stats.MaxTourPrice.Should().Be(0);
            stats.AvgVacationers.Should().Be(0);
            stats.WifiPercent.Should().Be(0);
            stats.AvgSurchargePercent.Should().Be(0);
            stats.AvgNights.Should().Be(0);
            stats.SurchargeShare.Should().Be(0);
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursService.GetTotalPrice(Tour)"/>
        /// на корректность расчета общей стоимости тура
        /// </summary>
        [Fact]
        public void GetTotalPrice_ShouldCalculateCorrectly()
        {
            // Arrange
            var expectedPrice = 3100;
            var tour = new Tour
            {
                CostPerVacationer = 500,
                VacationerCount = 2,
                NightCount = 3,
                Surcharge = 100
            };

            // Act
            var totalPrice = serviceWithEmptyRepositoryMock.GetTotalPrice(tour);

            // Assert
            totalPrice.Should().Be(expectedPrice);
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursService.GetTotalPrice(Tour)"/>
        /// на корректность возврата суммы только с учетом надбавки, когда базовая цена равна нулю
        /// </summary>
        [Fact]
        public void GetTotalPrice_ShouldReturnSurcharge_WhenBasePriceIsZero()
        {
            // Arrange
            var expectedPrice = 100;
            var tour = new Tour
            {
                CostPerVacationer = 0,
                VacationerCount = 0,
                NightCount = 0,
                Surcharge = 100
            };

            // Act
            var totalPrice = serviceWithEmptyRepositoryMock.GetTotalPrice(tour);

            // Assert
            totalPrice.Should().Be(expectedPrice);
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursService.GetPricePerNight(Tour)"/>
        /// на корректность расчета цены за ночь
        /// </summary>
        [Fact]
        public void GetPricePerNight_ShouldCalculateCorrectly()
        {
            // Arrange
            var expectedPrice = 500;
            var tour = new Tour
            {
                CostPerVacationer = 200,
                VacationerCount = 2,
                NightCount = 4,
                Surcharge = 400,
            };

            // Act
            var pricePerNight = serviceWithEmptyRepositoryMock.GetPricePerNight(tour);

            // Assert
            pricePerNight.Should().Be(expectedPrice);
        }


        /// <summary>
        /// Проверяет, что метод <see cref="ToursService.GetPricePerNight(Tour)"/>
        /// возвращает 0, если количество ночей равно 0.
        /// </summary>
        [Fact]
        public void GetPricePerNight_ShouldReturnZero_WhenNightCountIsZero()
        {
            // Arrange
            var tour = new Tour
            {
                CostPerVacationer = 500,
                VacationerCount = 2,
                NightCount = 0,
                Surcharge = 100
            };

            // Act
            var pricePerNight = serviceWithEmptyRepositoryMock.GetPricePerNight(tour);

            // Assert
            pricePerNight.Should().Be(0);
        }

        /// <summary>
        /// Проверяет метод <see cref="ToursService.GetNormalizedPrice(IEnumerable{Tour}, Tour)"/>
        /// на корректность нормализации цены в различных сценариях.
        /// </summary>
        /// <remarks>
        /// Формула:
        /// (total - min) / (max - min), либо 1 если max == min
        /// Покрываемые сценарии:
        /// - обычная нормализация (среднее значение)
        /// - все цены равны (защита от деления на 0)
        /// - минимальное значение (должно давать 0)
        /// - максимальное значение (должно давать 1)
        /// </remarks>
        [Theory]
        [InlineData(100, 200, 300, 200, 0.5)]  // средний случай: (200-100)/(300-100)=0.5
        [InlineData(100, 100, 100, 100, 1)]    // все цены равны → max == min → 1
        [InlineData(100, 200, 300, 100, 0)]    // минимальная цена → 0
        [InlineData(100, 200, 300, 300, 1)]    // максимальная цена → 1
        public void GetNormalizedPrice_ShouldReturnCorrectValue(
            int price1,
            int price2,
            int price3,
            int targetPrice,
            double expected)
        {
            // Arrange
            var target = new Tour
            {
                CostPerVacationer = targetPrice,
                VacationerCount = 1,
                NightCount = 1
            };

            var tours = new List<Tour>
            {
                new() { CostPerVacationer = price1, VacationerCount = 1, NightCount = 1 },
                new() { CostPerVacationer = price2, VacationerCount = 1, NightCount = 1 },
                new() { CostPerVacationer = price3, VacationerCount = 1, NightCount = 1 },
                target
            };

            // Act
            var result = serviceWithEmptyRepositoryMock.GetNormalizedPrice(tours, target);

            // Assert
            result.Should().BeApproximately((decimal)expected, 0.0001m);
        }
    }
}
