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
            var technical = new Technical(
                id: "12345678",
                specialtyId: 3,
                districtId: 2,
                profileUrl: "https://cdn-icons-png.flaticon.com/512/6073/6073873.png",
                firstname: "MARLON",
                lastname: "ROJAS",
                age: 28,
                genre: "FEMENINO",
                phone: 987654321,
                email: "mar.roj@gmail.com",
                technicalAvailability: ETechnicalAvailability.DISPONIBLE,
                technicalState: ETechnicalState.ACTIVO
            );

            var consumer = new Consumer(
                id: "87654321",
                districtId: 5,
                profileUrl: "https://cdn-icons-png.flaticon.com/512/6073/6073873.png",
                firstname: "LUANA",
                lastname: "PEREZ",
                age: 30,
                genre: "FEMENINO",
                phone: 944587415,
                email: "lu.pe@gmail.com",
                consumerState: EConsumerState.ACTIVO
            );

            // Act
            var chat = new Chat(
                id: 1,
                chatRoomId: 1,
                technicalId: "12345678",
                consumerId: "87654321",
                shippingDate: new DateTime(2025, 5, 14),
                message: "Hello, I need assistance with my service.",
                technical: technical,
                consumer: consumer
            );

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