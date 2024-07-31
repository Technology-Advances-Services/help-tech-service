using HelpTechService.Location.Domain.Model.Aggregates;
using HelpTechService.Location.Domain.Model.Queries.Department;
using HelpTechService.Location.Domain.Repositories;
using HelpTechService.Location.Domain.Services.Department;

namespace HelpTechService.Location.Application.Internal.QueryServices
{
    internal class DepartmentQueryService
        (IDepartmentRepository departmentRepository) :
        IDepartmentQueryService
    {
        public async Task<IEnumerable<Department>> Handle
            (GetAllDepartmentsQuery query) =>
            await departmentRepository.ListAsync();

        public async Task<Department?> Handle
            (GetDepartmentByIdQuery query) =>
            await departmentRepository
            .FindByIdAsync(query.Id);
    }
}