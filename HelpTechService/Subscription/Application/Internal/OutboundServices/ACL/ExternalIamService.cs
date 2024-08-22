using HelpTechService.IAM.Interfaces.ACL;

namespace HelpTechService.Subscription.Application.Internal.OutboundServices.ACL
{
    internal class ExternalIamService
        (IIamContextFacade iamContextFacade)
    {
        public async Task<bool> ExistsTechnicalById
            (string id) => await iamContextFacade
            .ExistsTechnicalById(id);

        public async Task<bool> ExistsConsumerById
            (string id) => await iamContextFacade
            .ExistsConsumerById(id);
    }
}