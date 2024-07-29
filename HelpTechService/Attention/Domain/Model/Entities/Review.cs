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
    }
}