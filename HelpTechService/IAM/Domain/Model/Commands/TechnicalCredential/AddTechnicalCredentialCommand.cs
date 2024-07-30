namespace HelpTechService.IAM.Domain.Model.Commands.TechnicalCredential
{
    public record AddTechnicalCredentialCommand
        (int TechnicalId, string Code);
}