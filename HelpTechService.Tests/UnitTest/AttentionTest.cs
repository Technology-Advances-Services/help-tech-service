using HelpTechService.Attention.Domain.Model.Aggregates;
using HelpTechService.Attention.Domain.Model.Commands.Review;
using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Attention.Domain.Model.ValueObjects.Job;
using HelpTechService.Attention.Domain.Model.ValueObjects.Review;
using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.ValueObjects.Consumer;

namespace HelpTechService.Tests.UnitTest
{
	public class AttentionServiceTest
	{
		[SetUp]
		public void SetUp() { }

		[Test]
		public void Attention_Constructor_WithParameters_ShouldInitializeProperties()
		{
			// Arrange
			var id = 1;
			var agendaId = 2;
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
			var consumer = new Consumer("0003", 5, "https://example.com/profile.jpg",
				"John", "Doe", 30, "Male", 123456789, "john.doe@gmail.com",
				consumerState: EConsumerState.ACTIVO);

			// Act
			var job = new Job(id, agendaId, consumerId, registrationDate,
				answerDate, workDate, address, description, time,
				laborBudget, materialBudget, jobState, agenda, consumer);

			// Assert
			Assert.That(job.Id, Is.EqualTo(id));
			Assert.That(job.AgendasId, Is.EqualTo(agendaId));
			Assert.That(job.ConsumersId, Is.EqualTo(int.Parse(consumerId)));
			Assert.That(job.RegistrationDate, Is.EqualTo(registrationDate));
			Assert.That(job.AnswerDate, Is.EqualTo(answerDate));
			Assert.That(job.WorkDate, Is.EqualTo(workDate));
			Assert.That(job.Address, Is.EqualTo(address));
			Assert.That(job.Description, Is.EqualTo(description));
			Assert.That(job.Time, Is.EqualTo(time));
			Assert.That(job.LaborBudget, Is.EqualTo(laborBudget));
			Assert.That(job.MaterialBudget, Is.EqualTo(materialBudget));
			Assert.That(job.AmountFinal, Is.EqualTo(laborBudget + materialBudget));
			Assert.That(job.Agenda, Is.EqualTo(agenda));
			Assert.That(job.Consumer, Is.EqualTo(consumer));
		}

		[Test]
		public void AddReview_Constructor_WithCommand_ShouldInitializeProperties()
		{

			// Arrange
			var jobCommand = new AddReviewToJobCommand
				("12345678", "87654321", 4, "Buen trabajo",
				EReviewState.PUBLICADO);

			// Act
			var review = new Review(jobCommand);

			// Assert
			Assert.That(review.TechnicalsId, Is.EqualTo(int.Parse(jobCommand.TechnicalId)));
			Assert.That(review.ConsumersId, Is.EqualTo(int.Parse(jobCommand.ConsumerId)));
            Assert.That(review.Score, Is.EqualTo(jobCommand.Score));
			Assert.That(review.Opinion, Is.EqualTo(jobCommand.Opinion));
			Assert.That(review.State, Is.EqualTo(jobCommand.ReviewState.ToString()));
		}
	}
}