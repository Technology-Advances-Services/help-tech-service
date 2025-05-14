using NUnit.Framework;
using Moq;
using System.Threading.Tasks;

namespace HelpTechService.Tests.UnitTest
{
	[TestFixture]
	public class AttentionServiceTests
	{

		[SetUp]
		public void SetUp()
		{

		}


		[Test]
		public void Attention_Constructor_WithParameters_ShouldInitializeProperties
		{
			// Arrange
			var id = 1;
			var agendasId = 2;
			var consumerId = "0003";
			var registrationDate = new DateTime(2025, 5, 14);
			var answerDate = new DateTime(2025, 5, 15);
			var workDate = new DateTime(2025, 5, 16);
			var address = "123 Main St";
			var description = "Repair broken window";
			var time = 3.5m;
			var laborBudget = 150.00m;
			var materialBudget = 75.00m;
			var jobState = EJobState.ENPROCESO;

			var agenda = new Agenda();
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
			var job = new Job(
				id: id,
				agendasId: agendasId,
				consumerId: consumerId,
				registrationDate: registrationDate,
				answerDate: answerDate,
				workDate: workDate,
				address: address,
				description: description,
				time: time,
				laborBudget: laborBudget,
				materialBudget: materialBudget,
				jobState: jobState,
				agenda: agenda,
				consumer: consumer
			);

			// Assert
			Assert.AreEqual(1, job.Id);
			Assert.AreEqual(2, job.AgendasId);
			Assert.AreEqual(3, job.ConsumersId); // "0003" convertido a 3
			Assert.AreEqual(new DateTime(2025, 5, 14), job.RegistrationDate);
			Assert.AreEqual(new DateTime(2025, 5, 15), job.AnswerDate);
			Assert.AreEqual(new DateTime(2025, 5, 16), job.WorkDate);
			Assert.AreEqual("123 Main St", job.Address);
			Assert.AreEqual("Repair broken window", job.Description);
			Assert.AreEqual(3.5m, job.Time);
			Assert.AreEqual(150.00m, job.LaborBudget);
			Assert.AreEqual(75.00m, job.MaterialBudget);
			Assert.AreEqual(225.00m, job.AmountFinal); // laborBudget + materialBudget
			Assert.AreEqual("EN PROCESO", job.State);
			Assert.AreEqual(agenda, job.Agenda);
			Assert.AreEqual(consumer, job.Consumer);
		}
	}

	[Test]
	public void AddReview_Constructor_WithCommand_ShouldInitializeProperties{

		// Arrange
		
		var addReviewToJobCommand = new AddReviewToJobCommand("TECH-001", "CONS-123", 4, "Buen trabajo", EReviewState);

		// Act
		var review = new Review(addReviewToJobCommand);

		// Assert

		Assert.Equal("TECH-001", review.TechnicalId);
		Assert.Equal("CONS-123", review.ConsumerId);
		Assert.Equal(4, review.Score);
		Assert.Equal("Buen trabajo", review.Opinion);
		Assert.Equal(EReviewState.Pending, review.ReviewState);
	}
}