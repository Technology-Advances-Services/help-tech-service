using HelpTechService.IAM.Domain.Model.Commands.Consumer;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.Consumer;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Application.Internal.CommandServices
{
    internal class ConsumerCommandService
        (IConsumerRepository consumerRepository,
        IUnitOfWork unitOfWork) :
        IConsumerCommandService
    {
        public async Task<bool> Handle
            (RegisterConsumerCommand command)
        {
            try
            {
                await consumerRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}