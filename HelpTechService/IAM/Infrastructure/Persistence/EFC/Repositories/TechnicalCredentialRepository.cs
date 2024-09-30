using Microsoft.EntityFrameworkCore;
using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    internal class TechnicalCredentialRepository
        (HelpTechContext context) :
        BaseRepository<TechnicalCredential>(context),
        ITechnicalCredentialRepository
    {
        public async Task<string?> FindByTechnicalIdAsync
            (int technicalId)
        {
            var result = await
                (from tc in Context.Set<TechnicalCredential>()
                 join te in Context.Set<Technical>()
                 on tc.TechnicalsId equals technicalId
                 where te.State == "ACTIVO"
                 select tc).AsNoTracking()
                 .FirstOrDefaultAsync();

            return result?.Code;
        }
    }
}