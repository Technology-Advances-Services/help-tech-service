using HelpTechService.IAM.Interfaces.REST.Resources.TechnicalCredential;

namespace HelpTechService.IAM.Interfaces.REST.Transform.TechnicalCredential
{
    public class TechnicalCredentialResourceFromEntityAssembler
    {
        public static TechnicalCredentialResource ToResourceFromEntity
            (Domain.Model.Entities.TechnicalCredential entity) =>
            new(entity.TechnicalsId, entity.Code);
    }
}