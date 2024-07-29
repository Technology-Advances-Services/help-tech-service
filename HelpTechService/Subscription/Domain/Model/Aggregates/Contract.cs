using HelpTechService.IAM.Domain.Model.Aggregates;

namespace HelpTechService.Subscription.Domain.Model.Aggregates
{
    public class Contract
    {
        public int Id { get; }
        public int MembershipsId { get; private set; }
        public int? TechnicalsId { get; private set; }
        public int? ConsumersId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime FinalDate { get; private set; }
        public string State { get; private set; } = null!;

        public virtual Consumer? Consumer { get; }
        public virtual Membership Membership { get; } = null!;
        public virtual Technical? Technical { get; }
    }
}