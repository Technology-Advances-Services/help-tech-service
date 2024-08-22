using HelpTechService.Subscription.Interfaces.REST.Resources.Contract;

namespace HelpTechService.Subscription.Interfaces.REST.Transform.Contract
{
    public class ConsumerContractResourceFromEntityAssembler
    {
        public static ConsumerContractResource ToResourceFromEntity
            (Domain.Model.Aggregates.Contract entity) =>
            new(entity.Id, entity.MembershipsId,
                entity.ConsumersId.ToString() ?? string.Empty,
                entity.StartDate, entity.FinalDate);
    }
}