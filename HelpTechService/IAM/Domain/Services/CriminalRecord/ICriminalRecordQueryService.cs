using HelpTechService.IAM.Domain.Model.Queries.CriminalRecord;

namespace HelpTechService.IAM.Domain.Services.CriminalRecord
{
    public interface ICriminalRecordQueryService
    {
        Task<IEnumerable<Model.Entities.CriminalRecord>> Handle
            (GetCriminalsRecordsByTechnicalIdQuery query);
    }
}