using HelpTechService.IAM.Domain.Model.ValueObjects.Technical;

namespace HelpTechService.IAM.Domain.Model.Queries.Technical
{
    public record GetTechnicalsByAvailabilityQuery
        (ETechnicalAvailability TechnicalAvailability);
}