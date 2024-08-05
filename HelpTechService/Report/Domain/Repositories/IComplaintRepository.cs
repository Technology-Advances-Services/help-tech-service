using HelpTechService.Report.Domain.Model.Aggregates;
using HelpTechService.Report.Domain.Model.ValueObjects.Complaint;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Report.Domain.Repositories
{
    public interface IComplaintRepository :
        IBaseRepository<Complaint>
    {
        Task<Complaint?> FindByJobIdAndSender
            (int jobId, EComplaintSender complaintSender);

        Task<Complaint?> FindByJobIdAndSenderAndState
            (int jobId, EComplaintSender complaintSender,
            EComplaintState complaintState);
    }
}