using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.IAM.Domain.Model.Queries.CriminalRecord;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.CriminalRecord;

namespace HelpTechService.IAM.Application.Internal.QueryServices
{
    internal class CriminalRecordQueryService
        (ICriminalRecordRepository criminalRecordRepository) :
        ICriminalRecordQueryService
    {
        public async Task<IEnumerable<CriminalRecord>> Handle
            (GetCriminalsRecordsByTechnicalIdQuery query) =>
            await criminalRecordRepository
            .FindByTechnicalIdAsync
            (query.TechnicalId);
    }
}