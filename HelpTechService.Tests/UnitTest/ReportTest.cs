using NUnit.Framework;
using Moq;
using System.Threading.Tasks;

namespace HelpTechService.Tests.UnitTest
{
    [TestFixture]
    public class ReportServiceTests
    {
        [SetUp]
        public void SetUp()
        {

        }


        [Test]
        public void Complaint_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var typeComplaintId = 1;
            var jobId = 2;
            var complaintSender = EComplaintSender.Consumer;
            var description = "The service was not completed as expected.";
            var complaintState = EComplaintState.Pending;
            var expectedRegistrationDate = DateTime.Now;

            // Act
            var complaint = new Complaint(
                typeComplaintId: typeComplaintId,
                jobId: jobId,
                complaintSender: complaintSender,
                description: description,
                complaintState: complaintState
            );

            // Assert
            Assert.AreEqual(1, complaint.TypesComplaintsId);
            Assert.AreEqual(2, complaint.JobsId);
            Assert.AreEqual("Consumer", complaint.Sender);
            Assert.AreEqual(description, complaint.Description);
            Assert.AreEqual("Pending", complaint.State);
            Assert.AreEqual(expectedRegistrationDate.Date, complaint.RegistrationDate.Date); // Compara solo la fecha
        }
    }
}
