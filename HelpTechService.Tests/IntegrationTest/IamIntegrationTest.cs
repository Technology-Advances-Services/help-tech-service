using Microsoft.AspNetCore.Mvc;
using Moq;
using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Queries.Consumer;
using HelpTechService.IAM.Domain.Model.Queries.Technical;
using HelpTechService.IAM.Domain.Model.Queries.ConsumerCredential;
using HelpTechService.IAM.Domain.Model.Queries.TechnicalCredential;
using HelpTechService.IAM.Domain.Services.Consumer;
using HelpTechService.IAM.Domain.Services.ConsumerCredential;
using HelpTechService.IAM.Domain.Services.Technical;
using HelpTechService.IAM.Domain.Services.TechnicalCredential;
using HelpTechService.IAM.Interfaces.REST;
using HelpTechService.IAM.Interfaces.REST.Resources.User;

namespace HelpTechService.Tests.IntegrationTest
{
    public class IamIntegrationTest
    {
        private Mock<ITechnicalQueryService> _technicalMockQueryService;
        private Mock<IConsumerQueryService> _consumerMockQueryService;
        private Mock<ITechnicalCredentialQueryService> _technicalCredMockQueryService;
        private Mock<IConsumerCredentialQueryService> _consumerCredMockQueryService;

        [SetUp]
        public void Setup()
        {
            _technicalMockQueryService = new Mock<ITechnicalQueryService>();
            _consumerMockQueryService = new Mock<IConsumerQueryService>();

            _technicalCredMockQueryService = new Mock<ITechnicalCredentialQueryService>();
            _consumerCredMockQueryService = new Mock<IConsumerCredentialQueryService>();
        }

        [Test]
        public async Task LoginIntegrationTest()
        {
            // Arrange
            var userResource = new UserResource
            ("76507123", "HolaMundo", "TECNICO");

            var value = new CredentialResult
            {
                Token = "",
                Result = true
            };

            if (userResource.Role == "TECNICO")
                _technicalCredMockQueryService
                    .Setup(s => s.Handle(It.Is
                    <GetTechnicalCredentialByTechnicalIdAndCodeQuery>
                    (q => q.TechnicalId == userResource.Username &&
                    q.Code == userResource.Password))).ReturnsAsync(value);

            else
                _consumerCredMockQueryService
                    .Setup(s => s.Handle(It.Is
                    <GetConsumerCredentialByConsumerIdAndCodeQuery>
                    (q => q.ConsumerId == userResource.Username &&
                    q.Code == userResource.Password))).ReturnsAsync(value);

            var controller = new AccessController
                (default, default, default, _technicalCredMockQueryService.Object,
                default, default,default, _consumerCredMockQueryService.Object);

            // Act
            var result = await controller.Login(userResource);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task InformationPerson()
        {
            // Arrange
            var userResource = new UserResource
            ("76507123", "HolaMundo", "TECNICO");

            var technical = new Technical();
            var consumer = new Consumer();

            if (userResource.Role == "TECNICO")
                _technicalMockQueryService
                    .Setup(s => s.Handle(It.Is<GetTechnicalByIdQuery>
                    (q => q.Id == userResource.Username)))
                    .ReturnsAsync(technical);

            else
                _consumerMockQueryService
                    .Setup(s => s.Handle(It.Is<GetConsumerByIdQuery>
                    (q => q.Id == userResource.Username)))
                    .ReturnsAsync(consumer);

            var controller = new InformationsController
                (_technicalMockQueryService.Object,
                _consumerMockQueryService.Object);

            // Act
            var result = userResource.Role == "TECNICO" ?
                await controller.TechnicalById(userResource.Username) :
                await controller.ConsumerById(userResource.Username);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }
    }

    public class CredentialResult
    {
        public string? Token { get; set; }
        public bool Result { get; set; }
    }
}