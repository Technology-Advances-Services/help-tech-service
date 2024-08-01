using HelpTechService.IAM.Domain.Model.Commands.CriminalRecord;
using HelpTechService.IAM.Interfaces.REST.Resources.CriminalRecord;

namespace HelpTechService.IAM.Interfaces.REST.Transform.CriminalRecord
{
    public class AddCriminalRecordToTechnicalCommandFromResourceAssembler
    {
        public static AddCriminalRecordToTechnicalCommand ToCommandFromResource
            (AddCriminalRecordToTechnicalResource resource) =>
            new(resource.TechnicalId, resource.FileUrl);
    }
}