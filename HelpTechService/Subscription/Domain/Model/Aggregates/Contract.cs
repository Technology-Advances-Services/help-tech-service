using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.Subscription.Domain.Model.Commands.Contract;
using HelpTechService.Subscription.Domain.Model.ValueObjects.Contract;

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

        public Contract()
        {
            this.MembershipsId = 0;
            this.TechnicalsId = null;
            this.ConsumersId = null;
        }
        public Contract
            (int membershipId, int? technicalId,
            int? consumerId, EContractState contractState)
        {
            this.MembershipsId = membershipId;
            this.TechnicalsId = technicalId;
            this.ConsumersId = consumerId;
            this.StartDate = DateTime.UtcNow;
            this.FinalDate = DateTime.UtcNow.AddMonths(6);
            this.State = contractState.ToString();
        }
        public Contract
            (CreateContractCommand command)
        {
            this.MembershipsId = command.MembershipId;
            this.TechnicalsId = command.TechnicalId;
            this.ConsumersId = command.ConsumerId;
            this.StartDate = DateTime.UtcNow;
            this.FinalDate = DateTime.UtcNow.AddMonths(6);
            this.State = command.ContractState.ToString();
        }
    }
}