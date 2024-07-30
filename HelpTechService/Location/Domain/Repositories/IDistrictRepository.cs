using HelpTechService.Location.Domain.Model.Aggregates;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Location.Domain.Repositories
{
    public interface IDistrictRepository :
        IBaseRepository<District>
    {
        Task<IEnumerable<District>> FindByDepartmentIdAsync
            (int departmentId);
    }
}