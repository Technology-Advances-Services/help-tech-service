using HelpTechService.Report.Domain.Model.Aggregates;

namespace HelpTechService.Report.Domain.Model.Entities
{
    public class TypeComplaint
    {
        public int Id { get; }
        public string Name { get; private set; } = null!;

        public virtual ICollection<Complaint> Complaints { get; } = [];
    }
}