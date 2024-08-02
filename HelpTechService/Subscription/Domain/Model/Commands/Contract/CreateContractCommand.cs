using HelpTechService.Subscription.Domain.Model.ValueObjects.Contract;

namespace HelpTechService.Subscription.Domain.Model.Commands.Contract
{
    public record CreateContractCommand
        (int MembershipId, int? TechnicalId,
        int? ConsumerId,
        EContractState ContractState);
}