using HelpTechService.Report.Interfaces.REST.Resources.Complaint;

namespace HelpTechService.Report.Interfaces.REST.Transform.Complaint
{
    public class ComplaintResourceFromEntityAssembler
    {
        public static ComplaintResource ToResourceFromEntity
            (Domain.Model.Aggregates.Complaint entity) =>
            new(entity.TypesComplaintsId, entity.JobsId,
                entity.Sender, entity.RegistrationDate,
                entity.Description, entity.State);
    }
}