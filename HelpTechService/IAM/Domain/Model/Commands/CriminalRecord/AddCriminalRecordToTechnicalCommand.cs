namespace HelpTechService.IAM.Domain.Model.Commands.CriminalRecord
{
    public record AddCriminalRecordToTechnicalCommand
        (string TechnicalId, string FileUrl);
}