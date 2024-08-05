using HelpTechService.Report.Domain.Model.ValueObjects.Complaint;

namespace HelpTechService.Report.Domain.Model.Commands.Complaint
{
    public record RegisterComplaintCommand
        (int TypeComplaintId, int JobId,
        EComplaintSender ComplaintSender,
        string Description,
        EComplaintState ComplaintState);
}