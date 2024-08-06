using HelpTechService.Statistic.Domain.Model.Queries;
using HelpTechService.Statistic.Domain.Repositories;
using HelpTechService.Statistic.Domain.Services;

namespace HelpTechService.Statistic.Application.Internal.QueryServices
{
    internal class StatisticQueryService
        (IStatisticRepository statisticRepository) :
        IStatisticQueryService
    {
        public async Task<dynamic?> Handle
            (GetGeneralTechnicalStatisticQuery query) =>
            await statisticRepository
            .GeneralTechnicalStatisticAsync
            (query.TechnicalId);

        public async Task<dynamic?> Handle
            (GetDetailedTechnicalStatisticQuery query) =>
            await statisticRepository
            .DetailedTechnicalStatisticAsync
            (query.TechnicalId, query.TypeStatistic);

        public async Task<dynamic?> Handle
            (GetReviewStatisticQuery query) =>
            await statisticRepository
            .ReviewStatisticAsync
            (query.TechnicalId);
    }
}