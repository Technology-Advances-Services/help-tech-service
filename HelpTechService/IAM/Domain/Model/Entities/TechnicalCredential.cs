using HelpTechService.IAM.Domain.Model.Aggregates;

namespace HelpTechService.IAM.Domain.Model.Entities
{
    public class TechnicalCredential
    {
        public int TechnicalsId { get; private set; }
        public string Code { get; private set; } = null!;

        public virtual Technical Technical { get; } = null!;
    }
}