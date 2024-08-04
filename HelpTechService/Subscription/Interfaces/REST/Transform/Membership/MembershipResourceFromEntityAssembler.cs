using HelpTechService.Subscription.Interfaces.REST.Resources.Membership;

namespace HelpTechService.Subscription.Interfaces.REST.Transform.Membership
{
    public class MembershipResourceFromEntityAssembler
    {
        public static MembershipResource ToResourceFromEntity
            (Domain.Model.Aggregates.Membership entity) =>
            new(entity.Id, entity.Name,
                entity.Price, entity.Policies);
    }
}