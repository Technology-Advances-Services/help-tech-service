using HelpTechService.Report.Domain.Model.Aggregates;
using HelpTechService.Report.Domain.Model.Queries.Complaint;
using HelpTechService.Report.Domain.Repositories;
using HelpTechService.Report.Domain.Services.Complaint;

namespace HelpTechService.Report.Application.Internal.QueryServices
{
    internal class ComplaintQueryService
        (IComplaintRepository complaintRepository) :
        IComplaintQueryService
    {
        public async Task<Complaint?> Handle
            (GetComplaintsByJobIdAndSenderQuery query) =>
            await complaintRepository
            .FindByJobIdAndSender
            (query.JobId, query.ComplaintSender);

        public async Task<Complaint?> Handle
            (GetComplaintsByJobIdAndSenderAndStateQuery query) =>
            await complaintRepository
            .FindByJobIdAndSenderAndState
            (query.JobId, query.ComplaintSender,
                query.ComplaintState);
    }
}