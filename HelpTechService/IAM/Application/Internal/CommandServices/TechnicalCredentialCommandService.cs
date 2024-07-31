using HelpTechService.IAM.Domain.Model.Commands.TechnicalCredential;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.TechnicalCredential;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Application.Internal.CommandServices
{
    internal class TechnicalCredentialCommandService
        (ITechnicalCredentialRepository technicalCredentialRepository,
        IUnitOfWork unitOfWork) :
        ITechnicalCredentialCommandService
    {
        public async Task<bool> Handle
            (AddTechnicalCredentialCommand command)
        {
            try
            {
                await technicalCredentialRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}