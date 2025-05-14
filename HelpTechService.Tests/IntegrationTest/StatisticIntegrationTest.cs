using Microsoft.AspNetCore.Mvc;
using Moq;
using HelpTechService.Statistic.Domain.Services;
using HelpTechService.Statistic.Domain.Model.Queries;
using HelpTechService.Statistic.Interfaces.REST;

namespace HelpTechService.Tests.IntegrationTest
{
    public class StatisticIntegrationTest
    {
        private Mock<IStatisticQueryService> _mockQueryService;

        [SetUp]
        public void Setup()
        {
            _mockQueryService = new Mock<IStatisticQueryService>();
        }

        [Test]
        public async Task GetGeneralTechnicalStatisticIntegrationTest()
        {
            // Arrange
            var technicalId = "76507123";
            var value = new[]
            {
                new
                {
                    AgendasId = 1,
                    TotalIncome = 371,
                    TotalConsumersServed = 5,
                    TotalWorkTime = 6,
                    TotalPendingsJobs = 1
                }
            };

            _mockQueryService
                .Setup(s => s.Handle(It.Is<GetGeneralTechnicalStatisticQuery>
                (q => q.TechnicalId == technicalId))).ReturnsAsync(value);

            var controller = new StatisticsController(_mockQueryService.Object);

            // Act
            var result = await controller.GeneralTechnicalStatistic(technicalId);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task GetDetailedTechnicalStatisticIntegrationTest()
        {
            // Arrange
            var technicalId = "76507123";
            var typeStatistic = "TOTAL";
            var value = new[]
            {
                new
                {
                    AgendasId = 1,
                    AverageIncome = 70.125,
                    TotalIncome = 561,
                    TotalConsumersServed = 8,
                    TotalWorkTime = 10,
                    TotalPendingsJobs = 1,
                    AverageScore = 3,
                    TotalReviews = 9
                }
            };

            _mockQueryService
                .Setup(s => s.Handle(It.Is<GetDetailedTechnicalStatisticQuery>
                (q => q.TechnicalId == technicalId &&
                q.TypeStatistic.ToString() == typeStatistic)))
                .ReturnsAsync(value);

            var controller = new StatisticsController(_mockQueryService.Object);

            // Act
            var result = await controller.DetailedTechnicalStatistic
                (technicalId, typeStatistic);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task GetReviewStatisticIntegrationTest()
        {
            // Arrange
            var technicalId = "76507123";
            var value = new[]
            {
                new Dictionary<string, int>
                {
                    { "1", 1 },
                    { "3", 3 },
                    { "4", 2 },
                    { "5", 1 },
                    { "AverageScore", 3 }
                }
            };


            _mockQueryService.Setup(s => s.Handle(It.Is<GetReviewStatisticQuery>
                (q => q.TechnicalId == technicalId))).ReturnsAsync(value);

            var controller = new StatisticsController(_mockQueryService.Object);

            // Act
            var result = await controller.ReviewStatistic(technicalId);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }
    }
}