using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Attention.Domain.Model.Queries.Review;
using HelpTechService.Attention.Domain.Repositories;
using HelpTechService.Attention.Domain.Services.Review;

namespace HelpTechService.Attention.Application.Internal.QueryServices
{
    internal class ReviewQueryService
        (IReviewRepository reviewRepository) :
        IReviewQueryService
    {
        public async Task<IEnumerable<Review>> Handle
            (GetReviewsByTechnicalIdQuery query) =>
            await reviewRepository
            .FindByTechnicalIdAsync
            (query.TechnicalId);
    }
}