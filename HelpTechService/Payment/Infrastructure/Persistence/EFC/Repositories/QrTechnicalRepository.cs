using Microsoft.EntityFrameworkCore;
using HelpTechService.Payment.Domain.Model.Aggregates;
using HelpTechService.Payment.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Payment.Infrastructure.Persistence.EFC.Repositories
{
    internal class QrTechnicalRepository
        (HelpTechContext context) :
        BaseRepository<QrTechnical>(context),
        IQrTechnicalRepository
    {
        public async Task<IEnumerable<QrTechnical>> FindByTechnicalIdAsync
            (int technicalId) => await Context.Set<QrTechnical>()
            .Where(q => q.TechnicalsId == technicalId && q.State == "ACTIVO")
            .AsNoTrackingWithIdentityResolution().ToListAsync();
    }
}