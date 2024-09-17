using HelpTechService.Subscription.Interfaces.REST.Resources.Contract;

namespace HelpTechService.Subscription.Interfaces.REST.Transform.Contract
{
    public class ConsumerContractResourceFromEntityAssembler
    {
        public static ConsumerContractResource ToResourceFromEntity
            (Domain.Model.Aggregates.Contract entity) =>
            new(entity.Id, entity.MembershipsId,

                entity.ConsumersId.HasValue &&
                entity.ConsumersId.Value.ToString().Length == 8 ?
                entity.ConsumersId.Value.ToString() :
                entity.ConsumersId.HasValue ? "0" +
                entity.ConsumersId.Value.ToString() : string.Empty,

                entity.Name, entity.Price, entity.Policies,
                entity.StartDate, entity.FinalDate);
    }
}