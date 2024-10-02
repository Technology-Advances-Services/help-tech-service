using Microsoft.EntityFrameworkCore;
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
            (int jobId, EComplaintSender complaintSender) =>
            await Context.Set<Complaint>()
            .Where(c => c.JobsId == jobId &&
            c.Sender == complaintSender.ToString())
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync();

        public async Task<Complaint?> FindByJobIdAndSenderAndState
            (int jobId, EComplaintSender complaintSender,
            EComplaintState complaintState) =>
            await Context.Set<Complaint>()
            .Where(c => c.JobsId == jobId &&
            c.Sender == complaintSender.ToString() &&
            c.State == complaintState.ToString())
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync();
    }
}