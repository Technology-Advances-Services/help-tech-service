using HelpTechService.IAM.Domain.Model.Queries.CriminalRecord;

namespace HelpTechService.IAM.Domain.Services.CriminalRecord
{
    public interface ICriminalRecordQueryService
    {
        Task<Model.Entities.CriminalRecord?> Handle
            (GetCriminalRecordByTechnicalIdQuery query);
    }
}