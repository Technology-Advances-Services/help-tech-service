using HelpTechService.Subscription.Domain.Model.Aggregates;
using HelpTechService.Subscription.Domain.Model.Queries.Membership;
using HelpTechService.Subscription.Domain.Repositories;
using HelpTechService.Subscription.Domain.Services.Membership;

namespace HelpTechService.Subscription.Application.Internal.QueryServices
{
    internal class MembershipQueryService
        (IMembershipRepository membershipRepository) :
        IMembershipQueryService
    {
        public async Task<IEnumerable<Membership>> Handle
            (GetAllMembershipsQuery query) =>
            await membershipRepository.ListAsync();

        public async Task<Membership?> Handle
            (GetMembershipByIdQuery query) =>
            await membershipRepository
            .FindByIdAsync(query.Id);
    }
}