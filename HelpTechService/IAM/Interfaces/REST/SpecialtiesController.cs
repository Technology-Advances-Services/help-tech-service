using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.IAM.Domain.Model.Queries.Specialty;
using HelpTechService.IAM.Domain.Services.Specialty;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using HelpTechService.IAM.Interfaces.REST.Transform.Specialty;

namespace HelpTechService.IAM.Interfaces.REST
{
    [Route("api/specialties/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public class SpecialtiesController
        (ISpecialtyQueryService specialtyQueryService) :
        ControllerBase
    {
        [Route("all-specialties")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllSpecialties()
        {
            var specialties = await specialtyQueryService
                .Handle(new GetAllSpecialtiesQuery());

            var specialtiesResources = specialties
                .Select(SpecialtyResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(specialtiesResources);
        }
    }
}