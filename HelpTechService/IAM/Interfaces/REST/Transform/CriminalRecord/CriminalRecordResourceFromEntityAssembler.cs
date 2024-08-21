using HelpTechService.IAM.Interfaces.REST.Resources.CriminalRecord;

namespace HelpTechService.IAM.Interfaces.REST.Transform.CriminalRecord
{
    public class CriminalRecordResourceFromEntityAssembler
    {
        public static CriminalRecordResource ToResourceFromEntity
            (Domain.Model.Entities.CriminalRecord entity) =>
            new(entity.TechnicalsId.ToString().Length == 8 ?
                entity.TechnicalsId.ToString() : "0" +
                entity.TechnicalsId.ToString(), entity.FileUrl);
    }
}