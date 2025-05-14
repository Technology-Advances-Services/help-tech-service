using Microsoft.AspNetCore.Mvc;
using Moq;
using HelpTechService.Attention.Domain.Services.Job;
using HelpTechService.Attention.Domain.Model.Commands.Job;
using HelpTechService.Attention.Interfaces.REST;
using HelpTechService.Attention.Interfaces.REST.Resources.Job;

namespace HelpTechService.Tests.IntegrationTest
{
    public class AttentionIntegrationTest
    {
        private Mock<IJobCommandService> _mockCommandService;
        private Mock<IJobQueryService> _mockQueryService;

        [SetUp]
        public void Setup()
        {
            _mockCommandService = new Mock<IJobCommandService>();
            _mockQueryService = new Mock<IJobQueryService>();
        }

        [Test]
        public async Task RegisterRequestJobIntegrationTest()
        {
            // Arrange
            var jobCommand = new RegisterRequestJobCommand
                (1, "07403440", "AV.MEXICO 554", "PINTAR ESCRITORIO",
                Attention.Domain.Model.ValueObjects.Job.EJobState.ENPROCESO);

            var jobResource = new RegisterRequestJobResource
                (1, "07403440", "AV.MEXICO 554", "PINTAR ESCRITORIO");

            _mockCommandService
                .Setup(s => s.Handle(It.Is<RegisterRequestJobCommand>
                (q => q.AgendaId == jobCommand.AgendaId &&
                q.ConsumerId == jobCommand.ConsumerId &&
                q.Address == jobCommand.Address &&
                q.Description == jobCommand.Description &&
                q.JobState == jobCommand.JobState))).ReturnsAsync(true);

            var controller = new JobsController
                (_mockCommandService.Object, _mockQueryService.Object);

            // Act
            var result = await controller.RegisterRequestJob(jobResource);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task AssignJobDetailIntegrationTest()
        {
            // Arrange

            var workDate = DateTime.Now.AddHours(2);

            var jobCommand = new AssignJobDetailCommand
                (22, workDate, 1, decimal.Parse("34.5"),
                decimal.Parse("34.5"));

            var jobResource = new AssignJobDetailResource
                (22, workDate, 1, decimal.Parse("34.5"),
                decimal.Parse("34.5"));

            _mockCommandService
                .Setup(s => s.Handle(It.Is<AssignJobDetailCommand>
                (q => q.Id == jobCommand.Id &&
                q.WorkDate == jobCommand.WorkDate &&
                q.Time == jobCommand.Time &&
                q.LaborBudget == jobCommand.LaborBudget &&
                q.MaterialBudget == jobCommand.MaterialBudget))).ReturnsAsync(true);

            var controller = new JobsController
                (_mockCommandService.Object, _mockQueryService.Object);

            // Act
            var result = await controller.AssignJobDetail(jobResource);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task UpdateJobStateIntegrationTest()
        {
            // Arrange
            var jobCommand = new UpdateJobStateCommand
                (22, Attention.Domain.Model.ValueObjects.Job.EJobState.COMPLETADO);

            var jobResource = new UpdateJobStateResource
                (22, "COMPLETADO");

            _mockCommandService
                .Setup(s => s.Handle(It.Is<UpdateJobStateCommand>
                (q => q.Id == jobCommand.Id &&
                q.JobState == jobCommand.JobState))).ReturnsAsync(true);

            var controller = new JobsController
                (_mockCommandService.Object, _mockQueryService.Object);

            // Act
            var result = await controller.UpdateJobState(jobResource);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }
    }
}