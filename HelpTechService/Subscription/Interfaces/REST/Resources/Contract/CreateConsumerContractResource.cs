namespace HelpTechService.Subscription.Interfaces.REST.Resources.Contract
{
    public record CreateConsumerContractResource
        (int MembershipId, string ConsumerId);
}