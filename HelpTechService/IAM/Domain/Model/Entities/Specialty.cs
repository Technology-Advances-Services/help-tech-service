using HelpTechService.IAM.Domain.Model.Aggregates;

namespace HelpTechService.IAM.Domain.Model.Entities
{
    public class Specialty
    {
        public int Id { get; }
        public string Name { get; private set; } = null!;

        public virtual ICollection<Technical> Technicals { get; } = [];
    }
}