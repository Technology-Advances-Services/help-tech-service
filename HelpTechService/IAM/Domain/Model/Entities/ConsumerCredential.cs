using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Commands.ConsumerCredential;

namespace HelpTechService.IAM.Domain.Model.Entities
{
    public class ConsumerCredential
    {
        public int ConsumersId { get; private set; }
        public string Code { get; private set; } = null!;

        public virtual Consumer Consumer { get; } = null!;

        public ConsumerCredential()
        {
            this.ConsumersId = 0;
            this.Code = string.Empty;
        }
        public ConsumerCredential
            (string consumerId, string code)
        {
            this.ConsumersId = int.Parse
                (consumerId.TrimStart('0'));
            this.Code = code;
        }
        public ConsumerCredential
            (AddConsumerCredentialCommand command)
        {
            this.ConsumersId = int.Parse
                (command.ConsumerId.TrimStart('0'));
            this.Code = command.Code;
        }
    }
}