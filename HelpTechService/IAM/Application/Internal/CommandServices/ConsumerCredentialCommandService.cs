using HelpTechService.IAM.Application.Internal.OutboundServices;
using HelpTechService.IAM.Domain.Model.Commands.ConsumerCredential;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.ConsumerCredential;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Application.Internal.CommandServices
{
    internal class ConsumerCredentialCommandService
        (IConsumerCredentialRepository consumerCredentialRepository,
        IUnitOfWork unitOfWork,
        IEncryptionService encryptionService) :
        IConsumerCredentialCommandService
    {
        public async Task<bool> Handle
            (AddConsumerCredentialCommand command)
        {
            try
            {
                var salt = encryptionService
                    .CreateSalt();

                var code = encryptionService
                    .HashCode(command.Code, salt);

                await consumerCredentialRepository
                    .AddAsync(new(command
                    .ConsumerId, string.Concat
                    (salt, code)));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> Handle
            (UpdateConsumerCredentialCommand command)
        {
            try
            {
                consumerCredentialRepository
                    .Update(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}