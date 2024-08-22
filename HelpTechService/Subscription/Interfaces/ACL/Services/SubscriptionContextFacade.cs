using HelpTechService.Subscription.Domain.Model.Queries.Contract;
using HelpTechService.Subscription.Domain.Services.Contract;

namespace HelpTechService.Subscription.Interfaces.ACL.Services
{
    internal class SubscriptionContextFacade
        (IContractQueryService contractQueryService) :
        ISubscriptionContextFacade
    {
        public async Task<bool> CurrentContractByTechnicalId
            (string technicalId) =>
            await contractQueryService.Handle
            (new GetContractByTechnicalIdQuery
                (technicalId)) != null;

        public async Task<bool> CurrentContractByConsumerId
            (string consumerId) =>
            await contractQueryService.Handle
            (new GetContractByConsumerIdQuery
                (consumerId)) != null;
    }
}