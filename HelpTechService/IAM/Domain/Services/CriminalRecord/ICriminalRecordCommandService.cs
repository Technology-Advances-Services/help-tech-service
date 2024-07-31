using HelpTechService.IAM.Domain.Model.Commands.CriminalRecord;

namespace HelpTechService.IAM.Domain.Services.CriminalRecord
{
    public interface ICriminalRecordCommandService
    {
        Task<bool> Handle
            (AddCriminalRecordToTechnicalCommand command);
    }
}