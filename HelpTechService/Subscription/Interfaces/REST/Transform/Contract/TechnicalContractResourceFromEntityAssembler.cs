using HelpTechService.Subscription.Interfaces.REST.Resources.Contract;

namespace HelpTechService.Subscription.Interfaces.REST.Transform.Contract
{
    public class TechnicalContractResourceFromEntityAssembler
    {
        public static TechnicalContractResource ToResourceFromEntity
            (Domain.Model.Aggregates.Contract entity) =>
            new(entity.Id, entity.MembershipsId,

                entity.TechnicalsId.HasValue &&
                entity.TechnicalsId.Value.ToString().Length == 8 ?
                entity.TechnicalsId.Value.ToString() :
                entity.TechnicalsId.HasValue ? "0" +
                entity.TechnicalsId.Value.ToString() : string.Empty,

                entity.Name, entity.Price, entity.Policies,
                entity.StartDate, entity.FinalDate);
    }
}