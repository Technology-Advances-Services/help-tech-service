namespace HelpTechService.Subscription.Interfaces.REST.Resources.Contract
{
    public record TechnicalContractResource
        (int Id, int MembershipId, string TechnicalId,
        DateTime StartDate, DateTime FinalDate);
}