using HelpTechService.Report.Domain.Model.ValueObjects.Complaint;

namespace HelpTechService.Report.Domain.Model.Queries.Complaint
{
    public record GetComplaintsByJobIdAndSenderQuery
        (int JobId, EComplaintSender ComplaintSender);
}