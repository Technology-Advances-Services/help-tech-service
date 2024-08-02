using HelpTechService.Subscription.Domain.Model.Queries.Membership;

namespace HelpTechService.Subscription.Domain.Services.Membership
{
    public interface IMembershipQueryService
    {
        Task<IEnumerable<Model.Aggregates.Membership>> Handle
            (GetAllMembershipsQuery query);

        Task<Model.Aggregates.Membership?> Handle
            (GetMembershipByIdQuery query);
    }
}