using HelpTechService.Report.Domain.Model.ValueObjects.Complaint;

namespace HelpTechService.Report.Domain.Model.Queries.Complaint
{
    public record GetComplaintsByJobIdAndSenderAndStateQuery
        (int JobId, EComplaintSender ComplaintSender,
        EComplaintState ComplaintState);
}