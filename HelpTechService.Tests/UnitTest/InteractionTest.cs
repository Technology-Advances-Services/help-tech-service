using NUnit.Framework;
using Moq;
using System.Threading.Tasks;

namespace HelpTechService.Tests.UnitTest
{
    [TestFixture]
    public class InteractionServiceTests
    {
        [SetUp]
        public void SetUp()
        {

        }


        [Test]
        public async Task Chat_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var id = 1;
            var chatRoomId = 2;
            var technicalId = "0001";
            var consumerId = "0003";
            var shippingDate = new DateTime(2025, 5, 14);
            var message = "Hello, I need assistance with my service.";

            var technical = new Technical(
                id: "0001",
                specialtyId: 3,
                districtId: 2,
                profileUrl: "https://example.com/technical.jpg",
                firstname: "Jane",
                lastname: "Smith",
                age: 28,
                genre: "Female",
                phone: 987654321,
                email: "jane.smith@example.com",
                technicalAvailability: ETechnicalAvailability.Available,
                technicalState: ETechnicalState.Active
            );

            var consumer = new Consumer(
                id: "0003",
                districtId: 5,
                profileUrl: "https://example.com/profile.jpg",
                firstname: "John",
                lastname: "Doe",
                age: 30,
                genre: "Male",
                phone: 123456789,
                email: "john.doe@example.com",
                consumerState: EConsumerState.Active
            );

            // Act
            var chat = new Chat(
                id: id,
                chatRoomId: chatRoomId,
                technicalId: technicalId,
                consumerId: consumerId,
                shippingDate: shippingDate,
                message: message,
                technical: technical,
                consumer: consumer
            );

            // Assert
            Assert.AreEqual(1, chat.Id);
            Assert.AreEqual(2, chat.ChatsRoomsId);
            Assert.AreEqual(1, chat.TechnicalsId); // "0001" convertido a 1
            Assert.AreEqual(3, chat.ConsumersId); // "0003" convertido a 3
            Assert.AreEqual(new DateTime(2025, 5, 14), chat.ShippingDate);
            Assert.AreEqual("Hello, I need assistance with my service.", chat.Message);
            Assert.AreEqual(technical, chat.Technical);
            Assert.AreEqual(consumer, chat.Consumer);
        }
    }
    }
}
