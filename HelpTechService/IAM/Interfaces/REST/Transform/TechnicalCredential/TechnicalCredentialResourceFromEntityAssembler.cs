using HelpTechService.IAM.Interfaces.REST.Resources.TechnicalCredential;

namespace HelpTechService.IAM.Interfaces.REST.Transform.TechnicalCredential
{
    public class TechnicalCredentialResourceFromEntityAssembler
    {
        public static TechnicalCredentialResource ToResourceFromEntity
            (Domain.Model.Entities.TechnicalCredential entity) =>
            new(entity.TechnicalsId.ToString().Length == 8 ?
                entity.TechnicalsId.ToString() : "0" +
                entity.TechnicalsId.ToString(),
                entity.Code);
    }
}