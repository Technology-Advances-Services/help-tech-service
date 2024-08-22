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
            (int.Parse(query.TechnicalId.TrimStart('0')));

        public async Task<dynamic?> Handle
            (GetDetailedTechnicalStatisticQuery query) =>
            await statisticRepository
            .DetailedTechnicalStatisticAsync
            (int.Parse(query.TechnicalId.TrimStart('0')),
                query.TypeStatistic);

        public async Task<dynamic?> Handle
            (GetReviewStatisticQuery query) =>
            await statisticRepository
            .ReviewStatisticAsync
            (int.Parse(query.TechnicalId.TrimStart('0')));
    }
}