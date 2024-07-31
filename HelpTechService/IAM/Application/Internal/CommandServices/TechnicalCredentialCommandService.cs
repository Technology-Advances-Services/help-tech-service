using HelpTechService.IAM.Application.Internal.OutboundServices;
using HelpTechService.IAM.Domain.Model.Commands.TechnicalCredential;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.TechnicalCredential;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Application.Internal.CommandServices
{
    internal class TechnicalCredentialCommandService
        (ITechnicalCredentialRepository technicalCredentialRepository,
        IUnitOfWork unitOfWork,
        IEncryptionService encryptionService) :
        ITechnicalCredentialCommandService
    {
        public async Task<bool> Handle
            (AddTechnicalCredentialCommand command)
        {
            try
            {
                var salt = encryptionService
                    .CreateSalt();

                var code = encryptionService
                    .HashCode(command.Code, salt);

                await technicalCredentialRepository
                    .AddAsync(new(command
                    .TechnicalId, string.Concat
                    (salt, code)));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}