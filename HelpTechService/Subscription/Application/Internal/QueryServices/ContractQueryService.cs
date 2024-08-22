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
            (int.Parse(query.TechnicalId
                .TrimStart('0')));

        public async Task<Contract?> Handle
            (GetContractByConsumerIdQuery query) =>
            await contractRepository
            .FindByConsumerIdAsync
            (int.Parse(query.ConsumerId
                .TrimStart('0')));
    }
}