namespace HelpTechService.Subscription.Interfaces.REST.Resources.Contract
{
    public record ConsumerContractResource
        (int Id, int MembershipId, string ConsumerId,
        string Name, decimal Price, string Policies,
        DateTime StartDate, DateTime FinalDate);
}