using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.ValueObjects.Technical;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Domain.Repositories
{
    public interface ITechnicalRepository :
        IBaseRepository<Technical>
    {
        Task<IEnumerable<Technical>> FindByAvailabilityAsync
            (ETechnicalAvailability technicalAvailability);
    }
}