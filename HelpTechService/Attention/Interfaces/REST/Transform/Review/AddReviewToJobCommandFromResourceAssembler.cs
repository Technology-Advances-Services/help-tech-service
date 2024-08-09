using HelpTechService.Attention.Domain.Model.Commands.Review;
using HelpTechService.Attention.Domain.Model.ValueObjects.Review;
using HelpTechService.Attention.Interfaces.REST.Resources.Review;

namespace HelpTechService.Attention.Interfaces.REST.Transform.Review
{
    public class AddReviewToJobCommandFromResourceAssembler
    {
        public static AddReviewToJobCommand ToCommandFromResource
            (AddReviewToJobResource resource) =>
            new(resource.TechnicalId, resource.ConsumerId,
                resource.Score, resource.Opinion,
                EReviewState.PUBLICADO);
    }
}