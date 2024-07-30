using HelpTechService.Location.Domain.Model.Aggregates;
using HelpTechService.Location.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Location.Infrastructure.Persistence.EFC.Repositories
{
    public class DepartmentRepository
        (HelpTechContext context) :
        BaseRepository<Department>(context),
        IDepartmentRepository
    { }
}