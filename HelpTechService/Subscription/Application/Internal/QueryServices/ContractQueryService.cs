using HelpTechService.Subscription.Domain.Model.Aggregates;
using HelpTechService.Subscription.Domain.Model.Queries.Contract;
using HelpTechService.Subscription.Domain.Repositories;
using HelpTechService.Subscription.Domain.Services.Contract;

namespace HelpTechService.Subscription.Application.Internal.QueryServices
{
    public class ContractQueryService
        (IContractRepository contractRepository) :
        IContractQueryService
    {
        public async Task<IEnumerable<Contract>> Handle
            (GetContractsByTechnicalIdQuery query) =>
            await contractRepository
            .FindByTechnicalIdAsync
            (query.TechnicalId);
    }
}