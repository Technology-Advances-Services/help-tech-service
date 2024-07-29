using HelpTechService.IAM.Domain.Model.Aggregates;

namespace HelpTechService.IAM.Domain.Model.Entities
{
    public class ConsumerCredential
    {
        public int ConsumersId { get; private set; }
        public string Code { get; private set; } = null!;

        public virtual Consumer Consumer { get; } = null!;
    }
}