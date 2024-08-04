namespace HelpTechService.Subscription.Interfaces.REST.Resources.Membership
{
    public record MembershipResource
        (int Id, string Name, decimal Price,
        string Policies);
}