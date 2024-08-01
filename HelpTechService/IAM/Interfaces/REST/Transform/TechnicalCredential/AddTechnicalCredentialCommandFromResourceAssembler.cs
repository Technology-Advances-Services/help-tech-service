using HelpTechService.IAM.Domain.Model.Commands.TechnicalCredential;
using HelpTechService.IAM.Interfaces.REST.Resources.TechnicalCredential;

namespace HelpTechService.IAM.Interfaces.REST.Transform.TechnicalCredential
{
    public class AddTechnicalCredentialCommandFromResourceAssembler
    {
        public static AddTechnicalCredentialCommand ToCommandFromResource
            (AddTechnicalCredentialResource resource) =>
            new(resource.TechnicalId, resource.Code);
    }
}