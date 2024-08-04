using HelpTechService.Subscription.Interfaces.REST.Resources.Contract;

namespace HelpTechService.Subscription.Interfaces.REST.Transform.Contract
{
    public class ConsumerContractResourceFromEntityAssembler
    {
        public static ConsumerContractResource ToResourceFromEntity
            (Domain.Model.Aggregates.Contract entity) =>
            new(entity.Id, entity.MembershipsId, Convert.ToInt32
                (entity.ConsumersId.ToString()),
                entity.StartDate, entity.FinalDate);
    }
}