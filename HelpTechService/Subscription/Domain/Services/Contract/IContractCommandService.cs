using HelpTechService.Subscription.Domain.Model.Commands.Contract;

namespace HelpTechService.Subscription.Domain.Services.Contract
{
    public interface IContractCommandService
    {
        Task<bool> Handle
            (CreateContractCommand command);
    }
}