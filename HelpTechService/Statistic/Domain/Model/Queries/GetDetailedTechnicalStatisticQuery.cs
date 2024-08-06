using HelpTechService.Statistic.Domain.Model.ValueObjects;

namespace HelpTechService.Statistic.Domain.Model.Queries
{
    public record GetDetailedTechnicalStatisticQuery
        (int TechnicalId, ETypeStatistic TypeStatistic);
}