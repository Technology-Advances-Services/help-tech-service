using HelpTechService.Report.Domain.Model.Aggregates;
using HelpTechService.Report.Domain.Model.ValueObjects.Complaint;

namespace HelpTechService.Tests.UnitTest
{
    public class ReportTest
    {
        [SetUp]
        public void SetUp() { }

        [Test]
        public void Complaint_Constructor_WithParameters_ShouldInitializeProperties()
        {
            // Arrange
            var typeComplaintId = 1;
            var jobId = 2;
            var complaintSender = EComplaintSender.CONSUMIDOR;
            var description = "The service was not completed as expected.";
            var complaintState = EComplaintState.ENTREGADO;

            // Act
            var complaint = new Complaint(typeComplaintId, jobId,
                complaintSender, description, complaintState);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(complaint.TypesComplaintsId, Is.EqualTo(typeComplaintId));
                Assert.That(complaint.JobsId, Is.EqualTo(jobId));
                Assert.That(complaint.Sender, Is.EqualTo(complaintSender.ToString()));
                Assert.That(complaint.Description, Is.EqualTo(description));
                Assert.That(complaint.State, Is.EqualTo(complaintState.ToString()));
            });
        }
    }
}