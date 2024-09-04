using HelpTechService.IAM.Domain.Model.Commands.TechnicalCredential;
using HelpTechService.IAM.Interfaces.REST.Resources.User;

namespace HelpTechService.IAM.Interfaces.REST.Transform.TechnicalCredential
{
    public class UpdateTechnicalCredentialCommandFromResourceAssembler
    {
        public static UpdateTechnicalCredentialCommand ToCommandFromResource
            (UpdateCredentialResource resource) =>
            new(resource.Username, resource.Code);
    }
}