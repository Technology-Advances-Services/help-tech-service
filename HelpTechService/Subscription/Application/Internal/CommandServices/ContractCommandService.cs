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
            try
            {
                bool result = false;

                if (!string.IsNullOrEmpty
                    (command.TechnicalId))
                    result = await externalIamService
                        .ExistsTechnicalById
                        (command.TechnicalId);

                else if (!string.IsNullOrEmpty
                    (command.ConsumerId))
                    result = await externalIamService
                        .ExistsConsumerById
                        (command.ConsumerId);

                if (result is false)
                    return false;

                await contractRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false;}
        }

        public async Task<bool> Handle
            (UpdateContractStateCommand command) =>
            await contractRepository
            .UpdateContractStateAsync
            (command.Id, command.ContractState);
    }
}