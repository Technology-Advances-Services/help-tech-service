using Microsoft.EntityFrameworkCore;
using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.ValueObjects.Technical;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;
using HelpTechService.Subscription.Domain.Model.Aggregates;

namespace HelpTechService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    internal class TechnicalRepository
        (HelpTechContext context) :
        BaseRepository<Technical>(context),
        ITechnicalRepository
    {
        public async Task<IEnumerable<Technical>> FindByAvailabilityAsync
            (ETechnicalAvailability technicalAvailability) =>
            await (from te in Context.Set<Technical>()
                   join co in Context.Set<Contract>()
                   on te.Id equals co.TechnicalsId
                   where te.Availability == technicalAvailability.ToString() &&
                   te.State == "ACTIVO" &&
                   co.State == "VIGENTE"
                   select te).ToListAsync();
    }
}