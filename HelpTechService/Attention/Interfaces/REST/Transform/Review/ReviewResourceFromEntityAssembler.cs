using HelpTechService.Attention.Interfaces.REST.Resources.Review;

namespace HelpTechService.Attention.Interfaces.REST.Transform.Review
{
    public class ReviewResourceFromEntityAssembler
    {
        public static ReviewResource ToResourceFromEntity
            (Domain.Model.Entities.Review entity) =>
            new(entity.TechnicalsId.ToString().Length == 8 ?
                entity.TechnicalsId.ToString() : "0" +
                entity.TechnicalsId.ToString(),

                entity.ConsumersId.ToString().Length == 8 ?
                entity.ConsumersId.ToString() : "0" +
                entity.ConsumersId.ToString(),

                entity.Score, entity.Opinion, entity.State);
    }
}