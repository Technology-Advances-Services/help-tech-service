using HelpTechService.Subscription.Application.Internal.OutboundServices.ACL;
using HelpTechService.Subscription.Domain.Model.Commands.Contract;
using HelpTechService.Subscription.Domain.Repositories;
using HelpTechService.Subscription.Domain.Services.Contract;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Subscription.Application.Internal.CommandServices
{
    public class ContractCommandService
        (IContractRepository contractRepository,
        IUnitOfWork unitOfWork,
        ExternalIamService externalIamService) :
        IContractCommandService
    {
        public async Task<bool> Handle
            (CreateContractCommand command)
        {
            bool result;

            if (int.TryParse(command
                .TechnicalId.ToString(),
                out int technicalId))
                result = await externalIamService
                    .ExistsTechnicalById
                    (technicalId);

            else if (int.TryParse(command
                .ConsumerId.ToString(),
                out int consumerId))
                result = await externalIamService
                    .ExistsConsumerById
                    (consumerId);

            else return false;

            if (result is false)
                return false;

            await contractRepository
                .AddAsync(new(command));

            await unitOfWork.CompleteAsync();

            return true;
        }
    }
}