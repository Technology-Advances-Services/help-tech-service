using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Commands.CriminalRecord;

namespace HelpTechService.IAM.Domain.Model.Entities
{
    public class CriminalRecord
    {
        public int Id { get; }
        public int TechnicalsId { get; private set; }
        public string FileUrl { get; private set; } = null!;

        public virtual Technical Technical { get; } = null!;

        public CriminalRecord()
        {
            this.TechnicalsId = 0;
            this.FileUrl = string.Empty;
        }
        public CriminalRecord
            (int technicalId, string fileUrl)
        {
            this.TechnicalsId = technicalId;
            this.FileUrl = fileUrl;
        }
        public CriminalRecord
            (AddCriminalRecordToTechnicalCommand command)
        {
            this.TechnicalsId = command.TechnicalId;
            this.FileUrl = command.FileUrl;
        }
    }
}