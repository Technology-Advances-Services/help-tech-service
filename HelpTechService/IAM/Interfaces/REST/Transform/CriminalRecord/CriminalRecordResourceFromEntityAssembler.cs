using HelpTechService.IAM.Interfaces.REST.Resources.CriminalRecord;

namespace HelpTechService.IAM.Interfaces.REST.Transform.CriminalRecord
{
    public class CriminalRecordResourceFromEntityAssembler
    {
        public static CriminalRecordResource ToResourceFromEntity
            (Domain.Model.Entities.CriminalRecord entity) =>
            new(entity.TechnicalsId, entity.FileUrl);
    }
}