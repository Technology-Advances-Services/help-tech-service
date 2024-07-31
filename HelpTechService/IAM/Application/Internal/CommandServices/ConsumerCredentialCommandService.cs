using HelpTechService.IAM.Domain.Model.Commands.ConsumerCredential;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.ConsumerCredential;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Application.Internal.CommandServices
{
    internal class ConsumerCredentialCommandService
        (IConsumerCredentialRepository consumerCredentialRepository,
        IUnitOfWork unitOfWork) :
        IConsumerCredentialCommandService
    {
        public async Task<bool> Handle
            (AddConsumerCredentialCommand command)
        {
            try
            {
                await consumerCredentialRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}