using HelpTechService.Subscription.Domain.Model.ValueObjects.Contract;

namespace HelpTechService.Subscription.Domain.Model.Commands.Contract
{
    public record CreateContractCommand
        (int MembershipId, string? TechnicalId,
        string? ConsumerId, string Name, decimal Price,
        string Policies, EContractState ContractState);
}