using HelpTechService.IAM.Domain.Model.Commands.ConsumerCredential;
using HelpTechService.IAM.Interfaces.REST.Resources.User;

namespace HelpTechService.IAM.Interfaces.REST.Transform.ConsumerCredential
{
    public class UpdateConsumerCredentialCommandFromResourceAssembler
    {
        public static UpdateConsumerCredentialCommand ToCommandFromResource
            (UpdateCredentialResource resource) =>
            new(resource.Username, resource.Code);
    }
}