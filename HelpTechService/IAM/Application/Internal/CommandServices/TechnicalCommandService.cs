using HelpTechService.IAM.Domain.Model.Commands.Technical;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.Technical;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Application.Internal.CommandServices
{
    internal class TechnicalCommandService
        (ITechnicalRepository technicalRepository,
        IUnitOfWork unitOfWork) :
        ITechnicalCommandService
    {
        public async Task<bool> Handle
            (RegisterTechnicalCommand command)
        {
            try
            {
                await technicalRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}