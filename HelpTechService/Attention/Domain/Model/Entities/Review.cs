using HelpTechService.Attention.Domain.Model.Commands.Review;
using HelpTechService.Attention.Domain.Model.ValueObjects.Review;
using HelpTechService.IAM.Domain.Model.Aggregates;

namespace HelpTechService.Attention.Domain.Model.Entities
{
    public class Review
    {
        public int Id { get; }
        public int TechnicalsId { get; private set; }
        public int ConsumersId { get; private set; }
        public DateTime ShippingDate { get; private set; }
        public int Score { get; private set; }
        public string Opinion { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual Consumer Consumer { get; } = null!;
        public virtual Technical Technical { get; } = null!;

        public Review()
        {
            this.TechnicalsId = 0;
            this.ConsumersId = 0;
            this.Score = 0;
            this.Opinion = string.Empty;
            this.State = string.Empty;
        }
        public Review
            (string technicalId, string consumerId,
            int score, string opinion,
            EReviewState reviewState)
        {
            this.TechnicalsId = int.Parse
                (technicalId.TrimStart('0'));
            this.ConsumersId = int.Parse
                (consumerId.TrimStart('0'));
            this.ShippingDate = DateTime.Now;
            this.Score = score;
            this.Opinion = opinion;
            this.State = reviewState.ToString();
        }
        public Review
            (AddReviewToJobCommand command)
        {
            this.TechnicalsId = int.Parse
                (command.TechnicalId.TrimStart('0'));
            this.ConsumersId = int.Parse
                (command.ConsumerId.TrimStart('0'));
            this.ShippingDate = DateTime.Now;
            this.Score = command.Score;
            this.Opinion = command.Opinion;
            this.State = command.ReviewState
                .ToString();
        }
    }
}