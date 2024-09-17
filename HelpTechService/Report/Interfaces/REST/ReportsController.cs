using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using HelpTechService.Report.Domain.Model.Queries.Complaint;
using HelpTechService.Report.Domain.Model.Queries.TypeComplaint;
using HelpTechService.Report.Domain.Model.ValueObjects.Complaint;
using HelpTechService.Report.Domain.Services.Complaint;
using HelpTechService.Report.Domain.Services.TypeComplaint;
using HelpTechService.Report.Interfaces.REST.Resources.Complaint;
using HelpTechService.Report.Interfaces.REST.Transform.Complaint;
using HelpTechService.Report.Interfaces.REST.Transform.TypeComplaint;

namespace HelpTechService.Report.Interfaces.REST
{
    [Route("api/reports/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize("TECNICO", "CONSUMIDOR")]
    public class ReportsController
        (ITypeComplaintQueryService typeComplaintQueryService,
        IComplaintCommandService complaintCommandService,
        IComplaintQueryService complaintQueryService) :
        ControllerBase
    {
        [Route("register-complaint")]
        [HttpPost]
        public async Task<IActionResult> RegisterComplaint
            ([FromBody] RegisterComplaintResource resource)
        {
            var result = await complaintCommandService
                .Handle(RegisterComplaintCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("all-types-complaints")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllTypesComplaints()
        {
            var typesComplaints = await typeComplaintQueryService
                .Handle(new GetAllTypesComplaintsQuery());

            var typesComplaintsResource = typesComplaints
                .Select(TypeComplaintResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(typesComplaintsResource);
        }

        [Route("type-complaint-by-id")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TypeComplaintById
            ([FromQuery] int id)
        {
            var typeComplaint = await typeComplaintQueryService
                .Handle(new GetTypeComplaintByIdQuery(id));

            if (typeComplaint is null)
                return BadRequest();

            var typeComplaintResource = TypeComplaintResourceFromEntityAssembler
                .ToResourceFromEntity(typeComplaint);

            return Ok(typeComplaintResource);
        }

        [Route("complaint-by-job-and-sender")]
        [HttpGet]
        public async Task<IActionResult> ComplaintByJobAndSender
            ([FromQuery] int jobId, [FromQuery] string sender)
        {
            if(!Enum.TryParse<EComplaintSender>
                (sender, out var complaintSender))
                return BadRequest();

            var complaint = await complaintQueryService
                .Handle(new GetComplaintsByJobIdAndSenderQuery
                (jobId, complaintSender));

            if (complaint is null)
                return BadRequest();

            var complaintResource = ComplaintResourceFromEntityAssembler
                .ToResourceFromEntity(complaint);

            return Ok(complaintResource);
        }

        [Route("complaint-by-job-and-sender-and-state")]
        [HttpGet]
        public async Task<IActionResult> ComplaintByJobAndSenderAndState
            ([FromQuery] int jobId, [FromQuery] string sender,
            [FromQuery] string state)
        {
            if (!Enum.TryParse<EComplaintSender>
                (sender, out var complaintSender) ||
                !Enum.TryParse<EComplaintState>
                (state, out var complaintState))
                return BadRequest();

            var complaint = await complaintQueryService
                .Handle(new GetComplaintsByJobIdAndSenderAndStateQuery
                (jobId, complaintSender, complaintState));

            if (complaint is null)
                return BadRequest();

            var complaintResource = ComplaintResourceFromEntityAssembler
                .ToResourceFromEntity(complaint);

            return Ok(complaintResource);
        }
    }
}