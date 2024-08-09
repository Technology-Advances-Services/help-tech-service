using HelpTechService.Attention.Interfaces.REST.Resources.Review;

namespace HelpTechService.Attention.Interfaces.REST.Transform.Review
{
    public class ReviewResourceFromEntityAssembler
    {
        public static ReviewResource ToResourceFromEntity
            (Domain.Model.Entities.Review entity) =>
            new(entity.TechnicalsId, entity.ConsumersId,
                entity.Score, entity.Opinion, entity.State);
    }
}