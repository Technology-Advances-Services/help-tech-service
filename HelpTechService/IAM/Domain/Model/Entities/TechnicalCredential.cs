using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Commands.TechnicalCredential;

namespace HelpTechService.IAM.Domain.Model.Entities
{
    public class TechnicalCredential
    {
        public int TechnicalsId { get; private set; }
        public string Code { get; private set; } = null!;

        public virtual Technical Technical { get; } = null!;

        public TechnicalCredential()
        {
            this.TechnicalsId = 0;
            this.Code = string.Empty;
        }
        public TechnicalCredential
            (int technicalId, string code)
        {
            this.TechnicalsId = technicalId;
            this.Code = code;
        }
        public TechnicalCredential
            (AddTechnicalCredentialCommand command)
        {
            this.TechnicalsId = command.TechnicalId;
            this.Code = command.Code;
        }
    }
}