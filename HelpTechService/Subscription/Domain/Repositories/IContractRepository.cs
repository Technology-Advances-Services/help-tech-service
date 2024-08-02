using HelpTechService.Shared.Domain.Repositories;
using HelpTechService.Subscription.Domain.Model.Aggregates;

namespace HelpTechService.Subscription.Domain.Repositories
{
    public interface IContractRepository :
        IBaseRepository<Contract>
    {
        Task<IEnumerable<Contract>> FindByTechnicalIdAsync
            (int technicalId);
    }
}