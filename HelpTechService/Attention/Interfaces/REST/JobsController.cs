using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.Attention.Domain.Model.Queries.Job;
using HelpTechService.Attention.Domain.Model.ValueObjects.Job;
using HelpTechService.Attention.Domain.Services.Job;
using HelpTechService.Attention.Interfaces.REST.Resources.Job;
using HelpTechService.Attention.Interfaces.REST.Transform.Job;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace HelpTechService.Attention.Interfaces.REST
{
    [Route("api/jobs/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public class JobsController
        (IJobCommandService jobCommandService,
        IJobQueryService jobQueryService) :
        ControllerBase
    {
        [Route("register-request-job")]
        [HttpPost]
        [Authorize("CONSUMIDOR")]
        public async Task<IActionResult> RegisterRequestJob
            ([FromBody] RegisterRequestJobResource resource)
        {
            var result = await jobCommandService
                .Handle(RegisterRequestJobCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("assign-job-detail")]
        [HttpPost]
        [Authorize("TECNICO")]
        public async Task<IActionResult> AssignJobDetail
            ([FromBody] AssignJobDetailResource resource)
        {
            var result = await jobCommandService
                .Handle(AssignJobDetailCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("update-job-state")]
        [HttpPost]
        [Authorize("TECNICO")]
        public async Task<IActionResult> UpdateJobState
            ([FromBody] UpdateJobStateResource resource)
        {
            var result = await jobCommandService
                .Handle(UpdateJobStateCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("job-by-id")]
        [HttpGet]
        [Authorize("TECNICO", "CONSUMIDOR")]
        public async Task<IActionResult> JobById
            ([FromQuery] int id)
        {
            var job = await jobQueryService
                .Handle(new GetJobByIdQuery(id));

            if (job is null)
                return BadRequest();

            var jobResource = JobResourceFromEntityAssembler
                .ToResourceFromEntity(job);

            return Ok(jobResource);
        }

        [Route("jobs-by-technical")]
        [HttpGet]
        [Authorize("TECNICO")]
        public async Task<IActionResult> JobsByTechnicalId
            ([FromQuery] string technicalId)
        {
            var jobs = await jobQueryService
                .Handle(new GetJobsByTechnicalIdQuery
                (technicalId));

            var jobsResource = jobs.Select
                (JobResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(jobsResource);
        }

        [Route("jobs-by-consumer")]
        [HttpGet]
        [Authorize("CONSUMIDOR")]
        public async Task<IActionResult> JobsByConsumerId
            ([FromQuery] string consumerId)
        {
            var jobs = await jobQueryService
                .Handle(new GetJobsByConsumerIdQuery
                (consumerId));

            var jobsResource = jobs.Select
                (JobResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(jobsResource);
        }

        [Route("jobs-by-technical-and-state")]
        [HttpGet]
        [Authorize("TECNICO")]
        public async Task<IActionResult> JobsByTechnicalIdAndState
            ([FromQuery] string technicalId, [FromQuery] string state)
        {
            if (!Enum.TryParse<EJobState>
                (state, out var jobState))
                return BadRequest();

            var jobs = await jobQueryService
                .Handle(new GetJobsByTechnicalIdAndStateQuery
                (technicalId, jobState));

            var jobsResource = jobs.Select
                (JobResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(jobsResource);
        }

        [Route("jobs-by-consumer-and-state")]
        [HttpGet]
        [Authorize("CONSUMIDOR")]
        public async Task<IActionResult> JobsByConsumerIdAndState
            ([FromQuery] string consumerId, [FromQuery] string state)
        {
            if (!Enum.TryParse<EJobState>
                (state, out var jobState))
                return BadRequest();

            var jobs = await jobQueryService
                .Handle(new GetJobsByConsumerIdAndStateQuery
                (consumerId, jobState));

            var jobsResource = jobs.Select
                (JobResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(jobsResource);
        }
    }
}