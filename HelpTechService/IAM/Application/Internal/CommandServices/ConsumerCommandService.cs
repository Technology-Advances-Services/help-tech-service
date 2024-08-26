using HelpTechService.IAM.Application.Internal.OutboundServices;
using HelpTechService.IAM.Application.Internal.OutboundServices.ACL;
using HelpTechService.IAM.Domain.Model.Commands.Consumer;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.Consumer;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Application.Internal.CommandServices
{
    internal class ConsumerCommandService
        (IConsumerRepository consumerRepository,
        IUnitOfWork unitOfWork,
        IReniecService reniecService,
        ExternalLocationService externalLocationService) :
        IConsumerCommandService
    {
        public async Task<bool> Handle
            (RegisterConsumerCommand command)
        {
            try
            {
                if (command.Age < 18 ||
                    command.Age > 70)
                    return false;

                if (!command.Genre.Equals
                    ("MASCULINO", StringComparison
                    .CurrentCultureIgnoreCase) &&
                    !command.Genre.Equals
                    ("FEMENINO", StringComparison
                    .CurrentCultureIgnoreCase))
                    return false;

                if (command.Phone.ToString()
                    .Length < 9 || command.Phone
                    .ToString().Length > 9)
                    return false;

                if (await externalLocationService
                    .ExistsDistrictById
                    (command.DistrictId)
                    is false || await reniecService
                    .ValidateDni(command.Id)
                    is false)
                    return false;

                await consumerRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}