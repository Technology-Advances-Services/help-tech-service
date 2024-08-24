using HelpTechService.IAM.Interfaces.REST.Resources.ConsumerCredential;

namespace HelpTechService.IAM.Interfaces.REST.Transform.ConsumerCredential
{
    public class ConsumerCredentialResourceFromEntityAssembler
    {
        public static ConsumerCredentialResource ToResourceFromEntity
            (Domain.Model.Entities.ConsumerCredential entity) =>
            new(entity.ConsumersId.ToString().Length == 8 ?
                entity.ConsumersId.ToString() : "0" +
                entity.ConsumersId.ToString(),
                entity.Code);
    }
}