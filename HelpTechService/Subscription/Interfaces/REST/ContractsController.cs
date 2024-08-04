using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using HelpTechService.Subscription.Domain.Model.Queries.Contract;
using HelpTechService.Subscription.Domain.Services.Contract;
using HelpTechService.Subscription.Interfaces.REST.Resources.Contract;
using HelpTechService.Subscription.Interfaces.REST.Transform.Contract;

namespace HelpTechService.Subscription.Interfaces.REST
{
    [Route("api/contracts/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public class ContractsController
        (IContractCommandService contractCommandService,
        IContractQueryService contractQueryService) :
        ControllerBase
    {
        [Route("create-technical-contract")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateTechnicalContract
            ([FromBody] CreateTechnicalContractResource resource)
        {
            var result = await contractCommandService
                .Handle(CreateTechnicalContractCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("create-consumer-contract")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateConsumerContract
            ([FromBody] CreateConsumerContractResource resource)
        {
            var result = await contractCommandService
                .Handle(CreateConsumerContractCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("contract-by-technical")]
        [HttpGet]
        [Authorize("TECNICO")]
        public async Task<IActionResult> GetContractByTechnicalId
            ([FromQuery] int technicalId)
        {
            var contract = await contractQueryService
                .Handle(new GetContractByTechnicalIdQuery
                (technicalId));

            if (contract is null)
                return BadRequest();

            var contractResource = TechnicalContractResourceFromEntityAssembler
                .ToResourceFromEntity(contract);

            return Ok(contractResource);
        }

        [Route("contract-by-consumer")]
        [HttpGet]
        [Authorize("CONSUMIDOR")]
        public async Task<IActionResult> GetContractByConsumerId
            ([FromQuery] int consumerId)
        {
            var contract = await contractQueryService
                .Handle(new GetContractByConsumerIdQuery
                (consumerId));

            if (contract is null)
                return BadRequest();

            var contractResource = ConsumerContractResourceFromEntityAssembler
                .ToResourceFromEntity(contract);

            return Ok(contractResource);
        }
    }
}