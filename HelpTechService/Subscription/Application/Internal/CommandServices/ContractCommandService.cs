using HelpTechService.Subscription.Domain.Model.Commands.Contract;
using HelpTechService.Subscription.Domain.Repositories;
using HelpTechService.Subscription.Domain.Services.Contract;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Subscription.Application.Internal.CommandServices
{
    public class ContractCommandService
        (IContractRepository contractRepository,
        IUnitOfWork unitOfWork) :
        IContractCommandService
    {
        public async Task<bool> Handle
            (CreateContractCommand command)
        {
            await contractRepository
                .AddAsync(new(command));

            await unitOfWork.CompleteAsync();

            return false;
        }
    }
}