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
            (string technicalId, string code)
        {
            this.TechnicalsId = int.Parse
                (technicalId.TrimStart('0'));
            this.Code = code;
        }
        public TechnicalCredential
            (AddTechnicalCredentialCommand command)
        {
            this.TechnicalsId = int.Parse
                (command.TechnicalId.TrimStart('0'));
            this.Code = command.Code;
        }

        public TechnicalCredential
            (UpdateTechnicalCredentialCommand command)
        {
            this.TechnicalsId = int.Parse
                (command.TechnicalId.TrimStart('0'));
            this.Code = command.Code;
        }
    }
}