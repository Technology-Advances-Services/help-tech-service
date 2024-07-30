namespace HelpTechService.IAM.Domain.Model.Commands.CriminalRecord
{
    public record AddCriminalRecordToTechnicalCommand
        (int TechnicalId, string FileUrl);
}