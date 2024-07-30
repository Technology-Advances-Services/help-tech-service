namespace HelpTechService.IAM.Domain.Model.Queries.TechnicalCredential
{
    public record GetTechnicalCredentialByTechnicalIdAndCodeQuery
        (int TechnicalId, string Code);
}