using HelpTechService.IAM.Domain.Model.Aggregates;

namespace HelpTechService.IAM.Domain.Model.Entities
{
    public class CriminalRecord
    {
        public int Id { get; }
        public int TechnicalsId { get; private set; }
        public string FileUrl { get; private set; } = null!;

        public virtual Technical Technical { get; } = null!;
    }
}