using HelpTechService.Payment.Domain.Model.Aggregates;
using HelpTechService.Payment.Domain.Model.Queries.QrTechnical;
using HelpTechService.Payment.Domain.Repositories;
using HelpTechService.Payment.Domain.Services.QrTechnical;

namespace HelpTechService.Payment.Application.Internal.QueryServices
{
    internal class QrTechnicalQueryService
        (IQrTechnicalRepository qrTechnicalRepository) :
        IQrTechnicalQueryService
    {
        public async Task<IEnumerable<QrTechnical>> Handle
            (GetQrTechnicalByTechnicalId query) =>
            await qrTechnicalRepository.FindByTechnicalIdAsync
            (int.Parse(query.TechnicalId.TrimStart('0')));
    }
}