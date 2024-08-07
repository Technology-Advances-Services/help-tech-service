using HelpTechService.IAM.Interfaces.ACL;

namespace HelpTechService.Statistic.Application.Internal.OutboundServices.ACL
{
    internal class ExternalIamService
        (IIamContextFacade iamContextFacade)
    {
        public async Task<bool> ExistsTechnicalById
            (int id) => await iamContextFacade
            .ExistsTechnicalById(id);
    }
}