using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.ValueObjects.Consumer;
using HelpTechService.IAM.Domain.Model.ValueObjects.Technical;
using HelpTechService.Interaction.Domain.Model.Aggregates;

namespace HelpTechService.Tests.UnitTest
{
    public class InteractionServiceTest
    {
        [SetUp]
        public void SetUp() { }

        [Test]
        public void Chat_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var technical = new Technical("12345678", 3, 2,
                "https://cdn-icons-png.flaticon.com/512/6073/6073873.png",
                "MARLON", "ROJAS", 28, "FEMENINO", 987654321, "mar.roj@gmail.com",
                ETechnicalAvailability.DISPONIBLE, ETechnicalState.ACTIVO);

            var consumer = new Consumer("87654321", 5,
                "https://cdn-icons-png.flaticon.com/512/6073/6073873.png",
                "LUANA", "PEREZ", 30, "FEMENINO", 944587415,
                "lu.pe@gmail.com", EConsumerState.ACTIVO);

            // Act
            var chat = new Chat(1, 1, "12345678", "87654321",
                new DateTime(2025, 5, 14), "Hello, I need assistance with my service.",
                technical, consumer);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(chat.Id, Is.EqualTo(1));
                Assert.That(chat.ChatsRoomsId, Is.EqualTo(1));
                Assert.That(chat.TechnicalsId, Is.EqualTo(technical.Id));
                Assert.That(chat.ConsumersId, Is.EqualTo(consumer.Id));
                Assert.That(chat.ShippingDate, Is.EqualTo(new DateTime(2025, 5, 14)));
                Assert.That(chat.Message, Is.EqualTo("Hello, I need assistance with my service."));
                Assert.That(chat.Technical, Is.EqualTo(technical));
                Assert.That(chat.Consumer, Is.EqualTo(consumer));
            });
        }
    }
}