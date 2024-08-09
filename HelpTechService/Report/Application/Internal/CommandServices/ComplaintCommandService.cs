using HelpTechService.Report.Application.Internal.OutboundServices.ACL;
using HelpTechService.Report.Domain.Model.Commands.Complaint;
using HelpTechService.Report.Domain.Repositories;
using HelpTechService.Report.Domain.Services.Complaint;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Report.Application.Internal.CommandServices
{
    internal class ComplaintCommandService
        (IComplaintRepository complaintRepository,
        IUnitOfWork unitOfWork,
        ExternalAttentionService externalAttentionService) :
        IComplaintCommandService
    {
        public async Task<bool> Handle
            (RegisterComplaintCommand command)
        {
            try
            {
                var result = await externalAttentionService
                    .ExistsJobById(command.JobId);

                if (result is false)
                    return false;

                await complaintRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}