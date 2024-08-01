using HelpTechService.IAM.Domain.Model.Commands.ConsumerCredential;
using HelpTechService.IAM.Interfaces.REST.Resources.ConsumerCredential;

namespace HelpTechService.IAM.Interfaces.REST.Transform.ConsumerCredential
{
    public class AddConsumerCredentialCommandFromResourceAssembler
    {
        public static AddConsumerCredentialCommand ToCommandFromResource
            (AddConsumerCredentialResource resource) =>
            new(resource.ConsumerId, resource.Code);
    }
}