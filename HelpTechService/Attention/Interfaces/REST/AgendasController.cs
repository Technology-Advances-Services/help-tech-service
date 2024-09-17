using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.Attention.Domain.Model.Queries.Agenda;
using HelpTechService.Attention.Interfaces.REST.Transform.Agenda;
using HelpTechService.Attention.Domain.Services.Agenda;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace HelpTechService.Attention.Interfaces.REST
{
    [Route("api/agendas/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize("TECNICO", "CONSUMIDOR")]
    public class AgendasController
        (IAgendaQueryService agendaQueryService) :
        ControllerBase
    {
        [Route("agenda-by-technical")]
        [HttpGet]
        public async Task<IActionResult> AgendaByTechnical
            ([FromQuery] string technicalId)
        {
            var agenda = await agendaQueryService
                .Handle(new GetAgendaByTechnicalIdQuery
                (technicalId));

            if (agenda is null)
                return BadRequest();

            var agendaResource = AgendaResourceFromEntityAssembler
                .ToResourceFromEntity(agenda);

            return Ok(agendaResource);
        }
    }
}