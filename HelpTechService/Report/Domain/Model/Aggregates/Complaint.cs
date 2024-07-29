using HelpTechService.Attention.Domain.Model.Aggregates;
using HelpTechService.Report.Domain.Model.Entities;

namespace HelpTechService.Report.Domain.Model.Aggregates
{
    public class Complaint
    {
        public int Id { get; }
        public int TypesComplaintsId { get; private set; }
        public int JobsId { get; private set; }
        public string Sender { get; private set; } = null!;
        public DateTime RegistrationDate { get; private set; }
        public string Description { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual Job Job { get; } = null!;
        public virtual TypeComplaint TypeComplaint { get; } = null!;
    }
}