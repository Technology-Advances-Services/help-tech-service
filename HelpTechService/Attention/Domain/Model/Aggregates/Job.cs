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
            this.RegistrationDate = ConvertDateTimeToLimaPeru(DateTime.Now);
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
            (int id, int agendasId, string consumerId,
            DateTime registrationDate, DateTime? answerDate,
            DateTime? workDate, string address, string description,
            decimal? time, decimal? laborBudget, decimal? materialBudget,
            EJobState jobState, Agenda agenda, Consumer consumer)
        {
            this.Id = id;
            this.AgendasId = agendasId;
            this.ConsumersId = int.TryParse
                (consumerId, out int consumersId) != false ?
                int.Parse(consumersId.ToString().TrimStart('0')) : 0;
            this.RegistrationDate = ConvertDateTimeToLimaPeru(registrationDate);
            this.AnswerDate = answerDate;
            this.WorkDate = workDate;
            this.Address = address;
            this.Description = description;
            this.Time = time;
            this.LaborBudget = laborBudget;
            this.MaterialBudget = materialBudget;
            this.AmountFinal = laborBudget +
                materialBudget;
            this.State = jobState == EJobState.ENPROCESO ?
                "EN PROCESO" : jobState.ToString();
            this.Agenda = agenda;
            this.Consumer = consumer;
        }
        public Job
            (RegisterRequestJobCommand command)
        {
            this.AgendasId = command.AgendaId;
            this.ConsumersId = int.TryParse
                (command.ConsumerId, out int consumersId) != false ?
                int.Parse(consumersId.ToString().TrimStart('0')) : 0;
            this.RegistrationDate = ConvertDateTimeToLimaPeru(DateTime.Now);
            this.Address = command.Address;
            this.Description = command.Description;
            this.State = command.JobState == EJobState.ENPROCESO ?
                "EN PROCESO" : command.JobState.ToString();
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
            this.State = command.JobState == EJobState.ENPROCESO ?
                "EN PROCESO" : command.JobState.ToString();
        }

        private static DateTime ConvertDateTimeToLimaPeru(DateTime localTime)
        {
            TimeZoneInfo limaTimeZone = TimeZoneInfo
                .FindSystemTimeZoneById("SA Pacific Standard Time");

            return TimeZoneInfo.ConvertTime
                (localTime, TimeZoneInfo.Local, limaTimeZone);
        }
    }
}