using HelpTechService.Attention.Domain.Model.ValueObjects.Review;

namespace HelpTechService.Attention.Domain.Model.Commands.Review
{
    public record AddReviewToJobCommand
        (string TechnicalId, string ConsumerId,
        int Score, string Opinion,
        EReviewState ReviewState);
}