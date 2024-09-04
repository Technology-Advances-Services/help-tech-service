using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.IAM.Domain.Model.Queries.ConsumerCredential;
using HelpTechService.IAM.Domain.Model.Queries.Technical;
using HelpTechService.IAM.Domain.Model.Queries.TechnicalCredential;
using HelpTechService.IAM.Domain.Model.ValueObjects.Credential;
using HelpTechService.IAM.Domain.Services.Consumer;
using HelpTechService.IAM.Domain.Services.ConsumerCredential;
using HelpTechService.IAM.Domain.Services.CriminalRecord;
using HelpTechService.IAM.Domain.Services.Technical;
using HelpTechService.IAM.Domain.Services.TechnicalCredential;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using HelpTechService.IAM.Interfaces.REST.Resources.Consumer;
using HelpTechService.IAM.Interfaces.REST.Resources.ConsumerCredential;
using HelpTechService.IAM.Interfaces.REST.Resources.CriminalRecord;
using HelpTechService.IAM.Interfaces.REST.Resources.Technical;
using HelpTechService.IAM.Interfaces.REST.Resources.TechnicalCredential;
using HelpTechService.IAM.Interfaces.REST.Resources.User;
using HelpTechService.IAM.Interfaces.REST.Transform.Consumer;
using HelpTechService.IAM.Interfaces.REST.Transform.ConsumerCredential;
using HelpTechService.IAM.Interfaces.REST.Transform.CriminalRecord;
using HelpTechService.IAM.Interfaces.REST.Transform.Technical;
using HelpTechService.IAM.Interfaces.REST.Transform.TechnicalCredential;

namespace HelpTechService.IAM.Interfaces.REST
{
    [Route("api/access/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public class AccessController
        (ITechnicalQueryService technicalQueryService,
        ITechnicalCommandService technicalCommandService,
        ITechnicalCredentialCommandService technicalCredentialCommandService,
        ITechnicalCredentialQueryService technicalCredentialQueryService,
        ICriminalRecordCommandService criminalRecordCommandService,
        IConsumerCommandService consumerCommandService,
        IConsumerCredentialCommandService consumerCredentialCommandService,
        IConsumerCredentialQueryService consumerCredentialQueryService) :
        ControllerBase
    {
        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login
            ([FromBody] UserResource resource)
        {
            if (!Enum.TryParse<ECredentialRole>
                (resource.Role, out var role))
                return Unauthorized();

            dynamic? result;

            result = role switch
            {
                ECredentialRole.TECNICO =>
                await technicalCredentialQueryService
                .Handle(new GetTechnicalCredentialByTechnicalIdAndCodeQuery
                (resource.Username, resource.Password)),

                ECredentialRole.CONSUMIDOR =>
                await consumerCredentialQueryService
                .Handle(new GetConsumerCredentialByConsumerIdAndCodeQuery
                (resource.Username, resource.Password)),

                _ => null
            };

            if (result is null)
                return BadRequest();

            return Ok(result.Token);
        }

        [Route("register-technical")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterTechnical
            ([FromBody] RegisterTechnicalResource resource)
        {
            var result = await technicalCommandService
                .Handle(RegisterTechnicalCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            result = await technicalCredentialCommandService
                .Handle(AddTechnicalCredentialCommandFromResourceAssembler
                .ToCommandFromResource(new AddTechnicalCredentialResource
                (resource.Id, resource.Code)));

            return Ok(result);
        }

        [Route("add-criminal-record-to-technical")]
        [HttpPost]
        [Authorize("TECNICO")]
        public async Task<IActionResult> AddCriminalRecordToTechnical
            ([FromBody] AddCriminalRecordToTechnicalResource resource)
        {
            var technical = await technicalQueryService
                .Handle(new GetTechnicalByIdQuery
                (resource.TechnicalId));

            if (technical is null)
                return BadRequest();

            var result = await criminalRecordCommandService
                .Handle(AddCriminalRecordToTechnicalCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("register-consumer")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterConsumer
            ([FromBody] RegisterConsumerResource resource)
        {
            var result = await consumerCommandService
                .Handle(RegisterConsumerCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            result = await consumerCredentialCommandService
                .Handle(AddConsumerCredentialCommandFromResourceAssembler
                .ToCommandFromResource(new AddConsumerCredentialResource
                (resource.Id, resource.Code)));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("update-credential")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateCredential
            ([FromBody] UpdateCredentialResource resource)
        {
            if (!Enum.TryParse<ECredentialRole>
                (resource.Role, out var role))
                return Unauthorized();

            dynamic? result;

            result = role switch
            {
                ECredentialRole.TECNICO =>
                await technicalCredentialCommandService
                .Handle(UpdateTechnicalCredentialCommandFromResourceAssembler
                .ToCommandFromResource(resource)),

                ECredentialRole.CONSUMIDOR =>
                await consumerCredentialCommandService
                .Handle(UpdateConsumerCredentialCommandFromResourceAssembler
                .ToCommandFromResource(resource)),

                _ => null
            };

            if (result is null)
                return BadRequest();

            return Ok(result);
        }
    }
}