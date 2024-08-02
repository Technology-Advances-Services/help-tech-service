using HelpTechService.Subscription.Domain.Model.Aggregates;

namespace HelpTechService.Subscription.Domain.Repositories
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> FindByTechnicalIdAsync
            (int technicalId);
    }
}