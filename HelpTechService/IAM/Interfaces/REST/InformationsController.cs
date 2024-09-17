using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.IAM.Domain.Model.Queries.Consumer;
using HelpTechService.IAM.Domain.Model.Queries.Technical;
using HelpTechService.IAM.Domain.Services.Consumer;
using HelpTechService.IAM.Domain.Services.Technical;
using HelpTechService.IAM.Domain.Model.ValueObjects.Technical;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using HelpTechService.IAM.Interfaces.REST.Transform.Technical;
using HelpTechService.IAM.Interfaces.REST.Transform.Consumer;

namespace HelpTechService.IAM.Interfaces.REST
{
    [Route("api/informations/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize("TECNICO", "CONSUMIDOR")]
    public class InformationsController
        (ITechnicalQueryService technicalQueryService,
        IConsumerQueryService consumerQueryService) :
        ControllerBase
    {
        [Route("technical-by-id")]
        [HttpGet]
        public async Task<IActionResult> TechnicalById
            ([FromQuery] string id)
        {
            var technical = await technicalQueryService
                .Handle(new GetTechnicalByIdQuery(id));

            if (technical is null)
                return BadRequest();

            var technicalResource = TechnicalResourceFromEntityAssembler
                .ToResourceFromEntity(technical);

            return Ok(technicalResource);
        }

        [Route("consumer-by-id")]
        [HttpGet]
        public async Task<IActionResult> ConsumerById
            ([FromQuery] string id)
        {
            var consumer = await consumerQueryService
                .Handle(new GetConsumerByIdQuery(id));

            if (consumer is null)
                return BadRequest();

            var consumerResource = ConsumerResourceFromEntityAssembler
                .ToResourceFromEntity(consumer);

            return Ok(consumerResource);
        }

        [Route("technicals-by-availability")]
        [HttpGet]
        public async Task<IActionResult> TechnicalsByAvailability
            (string availability)
        {
            if (!Enum.TryParse<ETechnicalAvailability>
                (availability, out var technicalAvailability))
                return BadRequest();

            var technicals = await technicalQueryService
                .Handle(new GetTechnicalsByAvailabilityQuery
                (technicalAvailability));

            var technicalsResource = technicals.Select
                (TechnicalResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(technicalsResource);
        }
    }
}