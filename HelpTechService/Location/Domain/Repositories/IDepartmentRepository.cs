using HelpTechService.Location.Domain.Model.Aggregates;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Location.Domain.Repositories
{
    public interface IDepartmentRepository :
        IBaseRepository<Department>
    { }
}