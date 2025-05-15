using HelpTechService.Subscription.Domain.Model.Aggregates;
using HelpTechService.Subscription.Domain.Model.ValueObjects.Contract;
using HelpTechService.Subscription.Domain.Model.ValueObjects.Membership;

namespace HelpTechService.Tests.UnitTest
{
    [TestFixture]
    public class SubscriptionServiceTest
    {
        [SetUp]
        public void SetUp() { }

        [Test]
        public void Contract_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var membershipId = 1;
            var technicalId = "12345678";
            var name = "Premium Service Contract";
            var price = 299.99m;
            var policies = "No refunds after 30 days.";
            var state = EContractState.VIGENTE;

            // Act
            var contract = new Contract(membershipId, technicalId,
                null, name, price, policies, state);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(contract.MembershipsId, Is.EqualTo(membershipId));
                Assert.That(contract.TechnicalsId, Is.EqualTo(int.Parse(technicalId)));
                Assert.That(contract.Name, Is.EqualTo(name));
                Assert.That(contract.Price, Is.EqualTo(price));
                Assert.That(contract.Policies, Is.EqualTo(policies));
                Assert.That(contract.State, Is.EqualTo(state.ToString()));
            });
        }

        [Test]
        public void Membership_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var id = 1;
            var name = "Gold Membership";
            var price = 199.99m;
            var policies = "Cancellation allowed within the first month.";
            var state = EMembershipState.VIGENTE;

            // Act
            var membership = new Membership(id, name, price,
                policies, state.ToString());

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(membership.Id, Is.EqualTo(id));
                Assert.That(membership.Name, Is.EqualTo(name));
                Assert.That(membership.Price, Is.EqualTo(price));
                Assert.That(membership.Policies, Is.EqualTo(policies));
                Assert.That(membership.State, Is.EqualTo(state.ToString()));
            });
        }
    }
}