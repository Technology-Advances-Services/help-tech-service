using HelpTechService.IAM.Domain.Model.Aggregates;

namespace HelpTechService.Location.Domain.Model.Aggregates
{
    public class District
    {
        public int Id { get; }
        public int DepartmentsId { get; private set; }
        public string Name { get; private set; } = null!;

        public virtual Department Department { get; } = null!;

        public virtual ICollection<Consumer> Consumers { get; } = [];
        public virtual ICollection<Technical> Technicals { get; } = [];
    }
}