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
        [Route("all-types-complaints")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllTypesComplaints()
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
        public async Task<IActionResult> GetTypeComplaintById
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

        [Route("register-complaint")]
        [HttpPost]
        public async Task<IActionResult> RegisterComplaint
            ([FromBody] RegisterComplaintResource resource)
        {
            var result = await complaintCommandService
                .Handle(RegisterComplaintCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            return Ok(result);
        }

        [Route("complaint-by-job-and-sender")]
        [HttpGet]
        public async Task<IActionResult> GetComplaintByJobIdAndSender
            ([FromQuery] int jobId, [FromQuery] string sender)
        {
            var complaint = await complaintQueryService
                .Handle(new GetComplaintsByJobIdAndSenderQuery
                (jobId, Enum.Parse<EComplaintSender>(sender)));

            if (complaint is null)
                return BadRequest();

            var complaintResource = ComplaintResourceFromEntityAssembler
                .ToResourceFromEntity(complaint);

            return Ok(complaintResource);
        }

        [Route("complaint-by-job-and-sender-and-state")]
        [HttpGet]
        public async Task<IActionResult> GetComplaintByJobIdAndSenderAndState
            ([FromQuery] int jobId, [FromQuery] string sender,
            [FromQuery] string complaintState)
        {
            var complaint = await complaintQueryService
                .Handle(new GetComplaintsByJobIdAndSenderAndStateQuery
                (jobId, Enum.Parse<EComplaintSender>(sender),
                Enum.Parse<EComplaintState>(complaintState)));

            if (complaint is null)
                return BadRequest();

            var complaintResource = ComplaintResourceFromEntityAssembler
                .ToResourceFromEntity(complaint);

            return Ok(complaintResource);
        }
    }
}