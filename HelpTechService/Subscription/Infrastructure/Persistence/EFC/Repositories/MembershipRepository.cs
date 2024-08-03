using HelpTechService.Subscription.Domain.Model.Aggregates;
using HelpTechService.Subscription.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Subscription.Infrastructure.Persistence.EFC.Repositories
{
    internal class MembershipRepository
        (HelpTechContext context) :
        BaseRepository<Membership>(context),
        IMembershipRepository
    { }
}