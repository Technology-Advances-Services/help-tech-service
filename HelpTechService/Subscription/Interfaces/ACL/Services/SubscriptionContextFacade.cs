using HelpTechService.Subscription.Domain.Model.Queries.Contract;
using HelpTechService.Subscription.Domain.Services.Contract;

namespace HelpTechService.Subscription.Interfaces.ACL.Services
{
    internal class SubscriptionContextFacade
        (IContractQueryService contractQueryService) :
        ISubscriptionContextFacade
    {
        public async Task<bool> CurrentContractByTechnicalId
            (int technicalId) =>
            await contractQueryService.Handle
            (new GetContractByTechnicalIdQuery
                (technicalId)) != null;

        public async Task<bool> CurrentContractByConsumerId
            (int consumerId) =>
            await contractQueryService.Handle
            (new GetContractByConsumerIdQuery
                (consumerId)) != null;
    }
}