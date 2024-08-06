using HelpTechService.Statistic.Domain.Model.ValueObjects;

namespace HelpTechService.Statistic.Domain.Repositories
{
    public interface IStatisticRepository
    {
        Task<dynamic?> DetailedTechnicalStatisticAsync
            (int technicalId, ETypeStatistic typeStatistic);

        Task<dynamic?> GeneralTechnicalStatisticAsync
            (int technicalId);

        Task<dynamic?> ReviewStatisticAsync
            (int technicalId);
    }
}