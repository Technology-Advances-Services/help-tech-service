using HelpTechService.Subscription.Application.Internal.OutboundServices.ACL;
using HelpTechService.Subscription.Domain.Model.Commands.Contract;
using HelpTechService.Subscription.Domain.Repositories;
using HelpTechService.Subscription.Domain.Services.Contract;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Subscription.Application.Internal.CommandServices
{
    internal class ContractCommandService
        (IContractRepository contractRepository,
        IUnitOfWork unitOfWork,
        ExternalIamService externalIamService) :
        IContractCommandService
    {
        public async Task<bool> Handle
            (CreateContractCommand command)
        {
            bool result = false;

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

            if (result is false)
                return false;

            await contractRepository
                .AddAsync(new(command));

            await unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> Handle
            (UpdateContractStateCommand command) =>
            await contractRepository
            .UpdateContractStateAsync
            (command.Id, command.ContractState);
    }
}