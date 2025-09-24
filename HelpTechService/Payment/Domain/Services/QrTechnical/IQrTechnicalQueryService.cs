using HelpTechService.Payment.Domain.Model.Queries.QrTechnical;

namespace HelpTechService.Payment.Domain.Services.QrTechnical
{
    public interface IQrTechnicalQueryService
    {
        Task<IEnumerable<Model.Aggregates.QrTechnical>> Handle
            (GetQrTechnicalByTechnicalId query);
    }
}