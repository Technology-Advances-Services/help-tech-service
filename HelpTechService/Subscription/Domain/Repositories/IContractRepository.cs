using HelpTechService.Shared.Domain.Repositories;
using HelpTechService.Subscription.Domain.Model.Aggregates;
using HelpTechService.Subscription.Domain.Model.ValueObjects.Contract;

namespace HelpTechService.Subscription.Domain.Repositories
{
    public interface IContractRepository :
        IBaseRepository<Contract>
    {
        Task<bool> UpdateContractStateAsync
            (int id, EContractState contractState);

        Task<Contract?> FindByTechnicalIdAsync
            (int technicalId);

        Task<Contract?> FindByConsumerIdAsync
            (int consumerId);
    }
}