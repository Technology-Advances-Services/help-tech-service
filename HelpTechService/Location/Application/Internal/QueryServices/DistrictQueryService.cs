using HelpTechService.Location.Domain.Model.Aggregates;
using HelpTechService.Location.Domain.Model.Queries.District;
using HelpTechService.Location.Domain.Repositories;
using HelpTechService.Location.Domain.Services.District;

namespace HelpTechService.Location.Application.Internal.QueryServices
{
    public class DistrictQueryService
        (IDistrictRepository districtRepository) :
        IDistrictQueryService
    {
        public async Task<bool> Handle
            (GetDistrictByIdQuery query) =>
            await districtRepository
            .FindByIdAsync(query.Id)
            is not null;

        public async Task<IEnumerable<District>> Handle
            (GetDistrictsByDepartmentIdQuery query) =>
            await districtRepository.FindByDepartmentIdAsync
            (query.DepartmentId);
    }
}