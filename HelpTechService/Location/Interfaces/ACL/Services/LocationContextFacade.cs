using HelpTechService.Location.Domain.Model.Queries.District;
using HelpTechService.Location.Domain.Services.District;

namespace HelpTechService.Location.Interfaces.ACL.Services
{
    public class LocationContextFacade
        (IDistrictQueryService districtQueryService) :
        ILocationContextFacade
    {
        public async Task<bool> ExistsDistrictById
            (int id) => await districtQueryService
            .Handle(new GetDistrictByIdQuery(id));
    }
}