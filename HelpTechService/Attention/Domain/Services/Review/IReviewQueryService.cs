using HelpTechService.Attention.Domain.Model.Queries.Review;

namespace HelpTechService.Attention.Domain.Services.Review
{
    public interface IReviewQueryService
    {
        Task<IEnumerable<Model.Entities.Review>> Handle
            (GetReviewsByTechnicalIdQuery query);
    }
}