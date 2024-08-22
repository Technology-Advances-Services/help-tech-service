using HelpTechService.Subscription.Interfaces.REST.Resources.Contract;

namespace HelpTechService.Subscription.Interfaces.REST.Transform.Contract
{
    public class TechnicalContractResourceFromEntityAssembler
    {
        public static TechnicalContractResource ToResourceFromEntity
            (Domain.Model.Aggregates.Contract entity) =>
            new(entity.Id, entity.MembershipsId, 
                entity.TechnicalsId.ToString() ?? string.Empty,
                entity.StartDate, entity.FinalDate);
    }
}