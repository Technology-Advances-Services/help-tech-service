using HelpTechService.Location.Interfaces.ACL;

namespace HelpTechService.IAM.Application.Internal.OutboundServices.ACL
{
    internal class ExternalLocationService
        (ILocationContextFacade locationContextFacade)
    {
        public async Task<bool> ExistsDistrictById
            (int id) => await locationContextFacade
            .ExistsDistrictById(id);
    }
}