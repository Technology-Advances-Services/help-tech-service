namespace HelpTechService.Subscription.Interfaces.REST.Resources.Contract
{
    public record TechnicalContractResource
        (int Id, int MembershipId, string TechnicalId,
        string Name, decimal Price, string Policies,
        DateTime StartDate, DateTime FinalDate);
}