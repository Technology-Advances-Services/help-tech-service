using HelpTechService.Attention.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Aggregates;

namespace HelpTechService.Attention.Domain.Model.Entities
{
    public class Agenda
    {
        public int Id { get; }
        public int TechnicalsId { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public virtual Technical Technical { get; } = null!;

        public virtual ICollection<Job> Jobs { get; } = [];
    }
}