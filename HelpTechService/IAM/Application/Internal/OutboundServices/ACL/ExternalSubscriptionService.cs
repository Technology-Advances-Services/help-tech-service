using HelpTechService.Subscription.Interfaces.ACL;

namespace HelpTechService.IAM.Application.Internal.OutboundServices.ACL
{
    internal class ExternalSubscriptionService
        (ISubscriptionContextFacade subscriptionContextFacade)
    {
        public async Task<bool> CurrentContractByTechnicalId
            (string technicalId) =>
            await subscriptionContextFacade
            .CurrentContractByTechnicalId
            (technicalId);

        public async Task<bool> CurrentContractByConsumerId
            (string consumerId) =>
            await subscriptionContextFacade
            .CurrentContractByConsumerId
            (consumerId);
    }
}