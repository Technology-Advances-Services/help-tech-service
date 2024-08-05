using HelpTechService.Subscription.Interfaces.ACL;

namespace HelpTechService.IAM.Application.Internal.OutboundServices.ACL
{
    public class ExternalSubscriptionService
        (ISubscriptionContextFacade subscriptionContextFacade)
    {
        public async Task<bool> CurrentContractByTechnicalId
            (int technicalId) =>
            await subscriptionContextFacade
            .CurrentContractByTechnicalId
            (technicalId);

        public async Task<bool> CurrentContractByConsumerId
            (int consumerId) =>
            await subscriptionContextFacade
            .CurrentContractByConsumerId
            (consumerId);
    }
}