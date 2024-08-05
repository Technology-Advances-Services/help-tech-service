using HelpTechService.Attention.Domain.Model.Aggregates;
using HelpTechService.Report.Domain.Model.Commands.Complaint;
using HelpTechService.Report.Domain.Model.Entities;
using HelpTechService.Report.Domain.Model.ValueObjects.Complaint;

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

        public Complaint()
        {
            this.TypesComplaintsId = 0;
            this.JobsId = 0;
            this.Description = string.Empty;
        }
        public Complaint
            (int typeComplaintId, int jobId,
            EComplaintSender complaintSender,
            string description,
            EComplaintState complaintState)
        {
            this.TypesComplaintsId = typeComplaintId;
            this.JobsId = jobId;
            this.Sender = complaintSender.ToString();
            this.RegistrationDate = DateTime.Now;
            this.Description = description;
            this.State = complaintState.ToString();
        }
        public Complaint
            (RegisterComplaintCommand command)
        {
            this.TypesComplaintsId = command.TypeComplaintId;
            this.JobsId = command.JobId;
            this.Sender = command.ComplaintSender.ToString();
            this.RegistrationDate = DateTime.Now;
            this.Description = command.Description;
            this.State = command.ComplaintState.ToString();
        }
    }
}