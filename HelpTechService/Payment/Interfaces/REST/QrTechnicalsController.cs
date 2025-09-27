using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using HelpTechService.Payment.Domain.Model.Queries.QrTechnical;
using HelpTechService.Payment.Domain.Services.QrTechnical;
using HelpTechService.Payment.Interfaces.REST.Transform.QrTechnical;
using HelpTechService.Payment.Interfaces.REST.Resources.QrTechnical;

namespace HelpTechService.Payment.Interfaces.REST
{
    [Route("api/qrtechnicals/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize("TECNICO")]
    public class QrTechnicalsController
        (IQrTechnicalCommandService qrTechnicalCommandService,
        IQrTechnicalQueryService qrTechnicalQueryService) :
        ControllerBase
    {
        [Route("add-qr-technical")]
        [HttpPost]
        public async Task<IActionResult> AddQrTechnical
            ([FromBody] AddQrTechnicalResource resource)
        {
            var result = await qrTechnicalCommandService
                .Handle(AddQrTechnicalCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("qr-by-technical")]
        [HttpGet]
        public async Task<IActionResult> QrByTechnicalId
            ([FromQuery] string technicalId)
        {
            var qrTechnical = await qrTechnicalQueryService
                .Handle(new GetQrTechnicalByTechnicalId(technicalId));

            var qrTechnicalResource = qrTechnical.Select
                (QrTechnicalResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(qrTechnicalResource);
        }
    }
}