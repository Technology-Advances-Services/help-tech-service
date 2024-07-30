using HelpTechService.Location.Domain.Model.Queries.District;

namespace HelpTechService.Location.Domain.Services.District
{
    public interface IDistrictQueryService
    {
        Task<bool> Handle
            (GetDistrictByIdQuery query);

        Task<IEnumerable<Model.Aggregates.District>> Handle
            (GetDistrictsByDepartmentIdQuery query);
    }
}