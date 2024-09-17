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
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Policies { get; private set; }
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
            this.Name = string.Empty;
            this.Policies = string.Empty;
        }
        public Contract
            (int membershipId, string? technicalId,
            string? consumerId, string name,
            decimal price, string policies,
            EContractState contractState)
        {
            this.MembershipsId = membershipId;
            this.TechnicalsId = int.TryParse
                (technicalId, out int technicalsId) != false ?
                int.Parse(technicalsId.ToString().TrimStart('0')) : null;
            this.ConsumersId = int.TryParse
                (consumerId, out int consumersId) != false ?
                int.Parse(consumersId.ToString().TrimStart('0')) : null;
            this.Name = name;
            this.Price = price;
            this.Policies = policies;
            this.StartDate = DateTime.Now;
            this.FinalDate = DateTime.Now.AddMonths(6);
            this.State = contractState.ToString();
        }
        public Contract
            (CreateContractCommand command)
        {
            this.MembershipsId = command.MembershipId;
            this.TechnicalsId = int.TryParse
                (command.TechnicalId, out int technicalsId) != false ?
                int.Parse(technicalsId.ToString().TrimStart('0')) : null;
            this.ConsumersId = int.TryParse
                (command.ConsumerId, out int consumersId) != false ?
                int.Parse(consumersId.ToString().TrimStart('0')) : null;
            this.Name = command.Name;
            this.Price = command.Price;
            this.Policies = command.Policies;
            this.StartDate = DateTime.Now;
            this.FinalDate = DateTime.Now.AddMonths(6);
            this.State = command.ContractState.ToString();
        }
    }
}