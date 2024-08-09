using HelpTechService.Attention.Interfaces.ACL;

namespace HelpTechService.Report.Application.Internal.OutboundServices.ACL
{
    internal class ExternalAttentionService
        (IAttentionContextFacade attentionContextFacade)
    {
        public async Task<bool> ExistsAttentionById
            (int id) => await attentionContextFacade
            .ExistsAttentionById(id);
    }
}