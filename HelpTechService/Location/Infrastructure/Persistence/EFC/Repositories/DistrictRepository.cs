using Microsoft.EntityFrameworkCore;
using HelpTechService.Location.Domain.Model.Aggregates;
using HelpTechService.Location.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Location.Infrastructure.Persistence.EFC.Repositories
{
    internal class DistrictRepository
        (HelpTechContext context) :
        BaseRepository<District>(context),
        IDistrictRepository
    {
        public async Task<IEnumerable<District>> FindByDepartmentIdAsync
            (int departmentId) => await Context.Set<District>()
            .Where(d => d.DepartmentsId == departmentId).ToListAsync();
    }
}