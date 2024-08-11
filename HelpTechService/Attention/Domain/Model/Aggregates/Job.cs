using System.Text.RegularExpressions;
using HelpTechService.Attention.Domain.Model.Commands.Job;
using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Attention.Domain.Model.ValueObjects.Job;
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
        public decimal? LaborBudget { get; private set; }
        public decimal? MaterialBudget { get; private set; }
        public decimal? AmountFinal { get; private set; }
        public string State { get; private set; } = null!;

        public virtual Agenda Agenda { get; } = null!;
        public virtual Consumer Consumer { get; } = null!;

        public virtual ICollection<Complaint> Complaints { get; } = [];

        public Job()
        {
            this.AgendasId = 0;
            this.ConsumersId = 0;
            this.RegistrationDate = DateTime.Now;
            this.AnswerDate = null;
            this.WorkDate = null;
            this.Address = string.Empty;
            this.Description = string.Empty;
            this.Time = 0;
            this.LaborBudget = 0;
            this.MaterialBudget = 0;
            this.AmountFinal = 0;
            this.State = string.Empty;
        }
        public Job
            (int agendasId, int consumersId,
            DateTime? answerDate, DateTime? workDate,
            string address, string description,
            decimal? time, decimal? laborBudget,
            decimal? materialBudget,
            EJobState jobState)
        {
            this.AgendasId = agendasId;
            this.ConsumersId = consumersId;
            this.RegistrationDate = DateTime.Now;
            this.AnswerDate = answerDate;
            this.WorkDate = workDate;
            this.Address = address;
            this.Description = description;
            this.Time = time;
            this.LaborBudget = laborBudget;
            this.MaterialBudget = materialBudget;
            this.AmountFinal = laborBudget +
                materialBudget;
            this.State = Regex.Replace(jobState
                .ToString(), "([A-Z])", " $1")
                .Trim();
        }
        public Job
            (RegisterRequestJobCommand command)
        {
            this.AgendasId = command.AgendaId;
            this.ConsumersId = command.ConsumerId;
            this.RegistrationDate = DateTime.Now;
            this.Address = command.Address;
            this.Description = command.Description;
            this.State = Regex.Replace
                (command.JobState
                .ToString(), "([A-Z])", " $1")
                .Trim();
        }
        public Job
            (AssignJobDetailCommand command)
        {
            this.Id = command.Id;
            this.WorkDate = command.WorkDate;
            this.Time = command.Time;
            this.LaborBudget = command.LaborBudget;
            this.MaterialBudget = command.MaterialBudget;
            this.AmountFinal = command.LaborBudget +
                command.MaterialBudget;
        }
        public Job
            (UpdateJobStateCommand command)
        {
            this.Id = command.Id;
            this.State = Regex.Replace
                (command.JobState
                .ToString(), "([A-Z])", " $1")
                .Trim();
        }
    }
}