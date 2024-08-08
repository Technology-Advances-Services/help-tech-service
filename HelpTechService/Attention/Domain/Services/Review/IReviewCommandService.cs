using HelpTechService.Attention.Domain.Model.Commands.Review;

namespace HelpTechService.Attention.Domain.Services.Review
{
    public interface IReviewCommandService
    {
        Task<bool> Handle
            (AddReviewToJobCommand command);
    }
}