using HelpTechService.IAM.Application.Internal.OutboundServices;
using HelpTechService.IAM.Application.Internal.OutboundServices.ACL;
using HelpTechService.IAM.Domain.Model.Commands.Technical;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.Technical;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Application.Internal.CommandServices
{
    internal class TechnicalCommandService
        (ITechnicalRepository technicalRepository,
        IUnitOfWork unitOfWork,
        IReniecService reniecService,
        ExternalLocationService externalLocationService) :
        ITechnicalCommandService
    {
        public async Task<bool> Handle
            (RegisterTechnicalCommand command)
        {
            try
            {
                if (await externalLocationService
                    .ExistsDistrictById
                    (command.DistrictId)
                    is false || await reniecService
                    .ValidateDni(command.Id)
                    is false)
                    return false;

                await technicalRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}