using HelpTechService.Subscription.Interfaces.REST.Resources.Contract;

namespace HelpTechService.Subscription.Interfaces.REST.Transform.Contract
{
    public class TechnicalContractResourceFromEntityAssembler
    {
        public static TechnicalContractResource ToResourceFromEntity
            (Domain.Model.Aggregates.Contract entity) =>
            new(entity.Id, entity.MembershipsId, Convert.ToInt32
                (entity.TechnicalsId.ToString()),
                entity.StartDate, entity.FinalDate);
    }
}