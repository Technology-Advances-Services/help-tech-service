namespace HelpTechService.Subscription.Interfaces.REST.Resources.Contract
{
    public record CreateTechnicalContractResource
        (int MembershipId, string TechnicalId,
        string Name, decimal Price, string Policies);
}