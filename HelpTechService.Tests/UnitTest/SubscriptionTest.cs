using NUnit.Framework;
using Moq;
using System.Threading.Tasks;

namespace HelpTechService.Tests.UnitTest
{
    [TestFixture]
    public class SubscriptionServiceTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Contract_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var membershipId = 1;
            var technicalId = "0001";
            var consumerId = "0003";
            var name = "Premium Service Contract";
            var price = 299.99m;
            var policies = "No refunds after 30 days.";
            var contractState = EContractState.Active;
            var expectedStartDate = DateTime.Now;
            var expectedFinalDate = expectedStartDate.AddMonths(6);

            // Act
            var contract = new Contract(
                membershipId: membershipId,
                technicalId: technicalId,
                consumerId: consumerId,
                name: name,
                price: price,
                policies: policies,
                contractState: contractState
            );

            // Assert
            Assert.AreEqual(1, contract.MembershipsId);
            Assert.AreEqual(1, contract.TechnicalsId); // "0001" convertido a 1
            Assert.AreEqual(3, contract.ConsumersId);   // "0003" convertido a 3
            Assert.AreEqual("Premium Service Contract", contract.Name);
            Assert.AreEqual(299.99m, contract.Price);
            Assert.AreEqual("No refunds after 30 days.", contract.Policies);
            Assert.AreEqual(expectedStartDate.Date, contract.StartDate.Date);
            Assert.AreEqual(expectedFinalDate.Date, contract.FinalDate.Date);
            Assert.AreEqual("Active", contract.State);
        }

        [Test]
        public void Membership_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var id = 1;
            var name = "Gold Membership";
            var price = 199.99m;
            var policies = "Cancellation allowed within the first month.";
            var membershipState = EMembershipState.Active;

            // Act
            var membership = new Membership(
                id: id,
                name: name,
                price: price,
                policies: policies,
                membershipState: membershipState
            );

            // Assert
            Assert.AreEqual(1, membership.Id);
            Assert.AreEqual("Gold Membership", membership.Name);
            Assert.AreEqual(199.99m, membership.Price);
            Assert.AreEqual("Cancellation allowed within the first month.", membership.Policies);
            Assert.AreEqual("Active", membership.State);
        }
    }
}
