using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using HelpTechService.Statistic.Domain.Services;
using HelpTechService.Statistic.Domain.Model.Queries;
using HelpTechService.Statistic.Domain.Model.ValueObjects;

namespace HelpTechService.Statistic.Interfaces.REST
{
    [Route("api/statistics/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize("TECNICO")]
    public class StatisticsController
        (IStatisticQueryService statisticQueryService) :
        ControllerBase
    {
        [Route("general-technical-statistic")]
        [HttpGet]
        public async Task<IActionResult> GeneralTechnicalStatistic
            ([FromQuery] string technicalId)
        {
            var result = await statisticQueryService
                .Handle(new GetGeneralTechnicalStatisticQuery
                (technicalId));

            return Ok(result);
        }

        [Route("detailed-technical-statistic")]
        [HttpGet]
        public async Task<IActionResult> DetailedTechnicalStatistic
            ([FromQuery] string technicalId, [FromQuery] string typeStatistic)
        {
            var result = await statisticQueryService
                .Handle(new GetDetailedTechnicalStatisticQuery
                (technicalId, Enum.Parse<ETypeStatistic>
                (typeStatistic)));

            return Ok(result);
        }

        [Route("review-statistic")]
        [HttpGet]
        public async Task<IActionResult> ReviewStatistic
            ([FromQuery] string technicalId)
        {
            var result = await statisticQueryService
                .Handle(new GetReviewStatisticQuery
                (technicalId));

            return Ok(result);
        }
    }
}