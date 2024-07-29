using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.Report.Domain.Model.Aggregates;

namespace HelpTechService.Attention.Domain.Model.Aggregates
{
    public class Job
    {
        public int Id { get; }
        public int AgendasId { get; private set; }
        public int ConsumersId { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime? AnswerDate { get; private set; }
        public DateTime? WorkDate { get; private set; }
        public string Address { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public decimal? Time { get; private set; }
        public double? LaborBudget { get; private set; }
        public double? MaterialBudget { get; private set; }
        public double? AmountFinal { get; private set; }
        public string State { get; private set; } = null!;

        public virtual Agenda Agenda { get; } = null!;
        public virtual Consumer Consumer { get; } = null!;

        public virtual ICollection<Complaint> Complaints { get; } = [];
    }
}