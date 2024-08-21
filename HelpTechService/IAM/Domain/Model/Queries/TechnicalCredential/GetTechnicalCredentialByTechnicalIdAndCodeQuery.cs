namespace HelpTechService.IAM.Domain.Model.Queries.TechnicalCredential
{
    public record GetTechnicalCredentialByTechnicalIdAndCodeQuery
        (string TechnicalId, string Code);
}