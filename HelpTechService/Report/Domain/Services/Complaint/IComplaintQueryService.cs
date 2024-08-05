using HelpTechService.Report.Domain.Model.Queries.Complaint;

namespace HelpTechService.Report.Domain.Services.Complaint
{
    public interface IComplaintQueryService
    {
        Task<Model.Aggregates.Complaint?> Handle
            (GetComplaintsByJobIdAndSenderQuery query);

        Task<Model.Aggregates.Complaint?> Handle
            (GetComplaintsByJobIdAndSenderAndStateQuery query);
    }
}