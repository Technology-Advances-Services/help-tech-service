using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using HelpTechService.Attention.Domain.Model.Queries.Review;
using HelpTechService.Attention.Domain.Services.Review;
using HelpTechService.Attention.Interfaces.REST.Resources.Review;
using HelpTechService.Attention.Interfaces.REST.Transform.Review;

namespace HelpTechService.Attention.Interfaces.REST
{
    [Route("api/reviews/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public class ReviewsController
        (IReviewCommandService reviewCommandService,
        IReviewQueryService reviewQueryService) :
        ControllerBase
    {
        [Route("add-review-to-job")]
        [HttpPost]
        [Authorize("CONSUMIDOR")]
        public async Task<IActionResult> AddReviewToJob
            ([FromBody] AddReviewToJobResource resource)
        {
            var result = await reviewCommandService
                .Handle(AddReviewToJobCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("reviews-by-technical")]
        [HttpGet]
        [Authorize("TECNICO", "CONSUMIDOR")]
        public async Task<IActionResult> GetReviewsByTechnicalId
            ([FromQuery] int technicalId)
        {
            var reviews = await reviewQueryService
                .Handle(new GetReviewsByTechnicalIdQuery
                (technicalId));

            var reviewsResource = reviews.Select
                (ReviewResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(reviewsResource);
        }
    }
}