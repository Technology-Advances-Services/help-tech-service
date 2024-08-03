using HelpTechService.IAM.Interfaces.ACL;

namespace HelpTechService.Subscription.Application.Internal.OutboundServices.ACL
{
    internal class ExternalIamService
        (IIamContextFacade iamContextFacade)
    {
        public async Task<bool> ExistsTechnicalById
            (int id) => await iamContextFacade
            .ExistsTechnicalById(id);

        public async Task<bool> ExistsConsumerById
            (int id) => await iamContextFacade
            .ExistsConsumerById(id);
    }
}