using HelpTechService.IAM.Domain.Model.Aggregates;

namespace HelpTechService.Payment.Domain.Model.Aggregates
{
    public class QrTechnical
    {
        public int Id { get; set; }
        public int TechnicalsId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string QrUrl { get; set; } = null!;
        public string State { get; set; } = null!;

        public virtual Technical Technical { get; } = null!;
    }
}