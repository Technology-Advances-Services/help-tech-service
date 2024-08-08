using HelpTechService.Attention.Domain.Model.ValueObjects.Review;

namespace HelpTechService.Attention.Domain.Model.Commands.Review
{
    public record AddReviewToJobCommand
        (int TechnicalId, int ConsumerId,
        int Score, string Opinion,
        EReviewState ReviewState);
}