using HelpTechService.Attention.Interfaces.REST.Resources.Job;

namespace HelpTechService.Attention.Interfaces.REST.Transform.Job
{
    public class JobResourceFromEntityAssembler
    {
        public static JobResource ToResourceFromEntity
            (Domain.Model.Aggregates.Job entity) =>
            new(entity.Id, entity.AgendasId,
                entity.ConsumersId.ToString().Length == 8 ?
                entity.ConsumersId.ToString() : "0" +
                entity.ConsumersId.ToString(),
                entity.AnswerDate, entity.WorkDate, entity.Address,
                entity.Description, entity.Time, entity.LaborBudget,
                entity.MaterialBudget, entity.State);
    }
}