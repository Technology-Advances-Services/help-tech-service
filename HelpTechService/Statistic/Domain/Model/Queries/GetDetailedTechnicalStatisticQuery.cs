using HelpTechService.Statistic.Domain.Model.ValueObjects;

namespace HelpTechService.Statistic.Domain.Model.Queries
{
    public record GetDetailedTechnicalStatisticQuery
        (string TechnicalId, ETypeStatistic TypeStatistic);
}