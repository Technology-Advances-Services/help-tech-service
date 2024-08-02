using HelpTechService.Shared.Domain.Repositories;
using HelpTechService.Subscription.Domain.Model.Aggregates;

namespace HelpTechService.Subscription.Domain.Repositories
{
    public interface IMembershipRepository :
        IBaseRepository<Membership>
    { }
}