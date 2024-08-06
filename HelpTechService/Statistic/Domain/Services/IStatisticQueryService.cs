using HelpTechService.Statistic.Domain.Model.Queries;

namespace HelpTechService.Statistic.Domain.Services
{
    public interface IStatisticQueryService
    {
        Task<dynamic?> Handle
            (GetGeneralTechnicalStatisticQuery query);

        Task<dynamic?> Handle
            (GetDetailedTechnicalStatisticQuery query);

        Task<dynamic?> Handle
            (GetReviewStatisticQuery query);
    }
}