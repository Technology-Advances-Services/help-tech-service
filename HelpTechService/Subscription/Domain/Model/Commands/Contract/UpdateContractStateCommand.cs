using HelpTechService.Subscription.Domain.Model.ValueObjects.Contract;

namespace HelpTechService.Subscription.Domain.Model.Commands.Contract
{
    public record UpdateContractStateCommand
        (int Id, EContractState ContractState);
}