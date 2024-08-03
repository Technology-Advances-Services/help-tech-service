using HelpTechService.Subscription.Domain.Model.Aggregates;
using HelpTechService.Subscription.Domain.Model.Queries.Contract;
using HelpTechService.Subscription.Domain.Repositories;
using HelpTechService.Subscription.Domain.Services.Contract;

namespace HelpTechService.Subscription.Application.Internal.QueryServices
{
    internal class ContractQueryService
        (IContractRepository contractRepository) :
        IContractQueryService
    {
        public async Task<Contract?> Handle
            (GetContractByTechnicalIdQuery query) =>
            await contractRepository
            .FindByTechnicalIdAsync
            (query.TechnicalId);

        public async Task<Contract?> Handle
            (GetContractByConsumerIdQuery query) =>
            await contractRepository
            .FindByConsumerIdAsync
            (query.ConsumerId);
    }
}