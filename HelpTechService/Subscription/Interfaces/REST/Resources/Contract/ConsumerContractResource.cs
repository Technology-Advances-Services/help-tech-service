namespace HelpTechService.Subscription.Interfaces.REST.Resources.Contract
{
    public record ConsumerContractResource
        (int Id, int MembershipId, int ConsumerId,
        DateTime StartDate, DateTime FinalDate);
}