using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.Location.Domain.Model.Queries.Department;
using HelpTechService.Location.Domain.Model.Queries.District;
using HelpTechService.Location.Domain.Services.Department;
using HelpTechService.Location.Domain.Services.District;
using HelpTechService.Location.Interfaces.REST.Transform.Department;
using HelpTechService.Location.Interfaces.REST.Transform.District;

namespace HelpTechService.Location.Interfaces.REST
{
    [Route("api/locations/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class LocationsController
            (IDepartmentQueryService departmentQueryService,
            IDistrictQueryService districtQueryService) :
            ControllerBase
    {
        [Route("all-departments")]
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var deparments = await departmentQueryService
                .Handle(new GetAllDepartmentsQuery());

            var deparmentsResource = deparments
                .Select(DepartmentResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(deparmentsResource);
        }

        [Route("department-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentById
            ([FromQuery] int id)
        {
            var department = await departmentQueryService
                .Handle(new GetDepartmentByIdQuery(id));

            if (department is null)
                return BadRequest();

            var departmentResource = DepartmentResourceFromEntityAssembler
                .ToResourceFromEntity(department);

            return Ok(departmentResource);
        }

        [Route("districts-by-department")]
        [HttpGet]
        public async Task<IActionResult> GetDistrictsByDepartmentId
            ([FromQuery] int departmentId)
        {
            var districts = await districtQueryService
                .Handle(new GetDistrictsByDepartmentIdQuery
                (departmentId));

            var districtsResource = districts
                .Select(DistrictResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(districtsResource);
        }
    }
}