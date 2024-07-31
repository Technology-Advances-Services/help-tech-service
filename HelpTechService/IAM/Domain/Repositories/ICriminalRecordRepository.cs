using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Domain.Repositories
{
    public interface ICriminalRecordRepository :
        IBaseRepository<CriminalRecord>
    {
        Task<CriminalRecord?> FindByTechnicalIdAsync
            (int technicalId);
    }
}