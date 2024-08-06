using HelpTechService.Report.Domain.Model.Aggregates;
using HelpTechService.Report.Domain.Model.ValueObjects.Complaint;
using HelpTechService.Report.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Report.Infrastructure.Persistence.EFC.Repositories
{
    internal class ComplaintRepository
        (HelpTechContext context) :
        BaseRepository<Complaint>(context),
        IComplaintRepository
    {
        public async Task<Complaint?> FindByJobIdAndSender
            (int jobId, EComplaintSender complaintSender)
        {
            Task<Complaint?> queryAsync = new(() =>
            {
                return
                (from co in Context.Set<Complaint>().ToList()
                 where co.JobsId == jobId &&
                 co.Sender == complaintSender.ToString()
                 select co).FirstOrDefault();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<Complaint?> FindByJobIdAndSenderAndState
            (int jobId, EComplaintSender complaintSender,
            EComplaintState complaintState)
        {
            Task<Complaint?> queryAsync = new(() =>
            {
                return
                (from co in Context.Set<Complaint>().ToList()
                 where co.JobsId == jobId &&
                 co.Sender == complaintSender.ToString() &&
                 co.State == complaintState.ToString()
                 select co).FirstOrDefault();
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}