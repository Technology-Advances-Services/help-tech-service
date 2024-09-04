namespace HelpTechService.IAM.Domain.Model.Commands.TechnicalCredential
{
    public record UpdateTechnicalCredentialCommand
        (string TechnicalId, string Code);
}