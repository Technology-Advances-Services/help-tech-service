using HelpTechService.Payment.Domain.Model.Aggregates;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Payment.Domain.Repositories
{
    public interface IQrTechnicalRepository :
        IBaseRepository<QrTechnical>
    {
        Task<IEnumerable<QrTechnical>> FindByTechnicalIdAsync(int technicalId);
    }
}