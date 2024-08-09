using HelpTechService.Attention.Application.Internal.OutboundServices.ACL;
using HelpTechService.Attention.Domain.Model.Commands.Job;
using HelpTechService.Attention.Domain.Repositories;
using HelpTechService.Attention.Domain.Services.Job;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Attention.Application.Internal.CommandServices
{
    internal class JobCommandService
        (IJobRepository jobRepository,
        IUnitOfWork unitOfWork,
        ExternalIamService externalIamService) :
        IJobCommandService
    {
        public async Task<bool> Handle
            (RegisterRequestJobCommand command)
        {
            try
            {
                if (await externalIamService
                    .ExistsConsumerById
                    (command.ConsumerId)
                    is false) return false;

                await jobRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> Handle
            (AssignJobDetailCommand command) =>
            await jobRepository.AssignJobDetailAsync
            (command.Id, command.WorkDate,
                command.Time, command.LaborBudget,
                command.MaterialBudget);

        public async Task<bool> Handle
            (UpdateJobStateCommand command) =>
            await jobRepository.UpdateJobStateAsync
            (command.Id, command.JobState);
    }
}