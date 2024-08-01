using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    public class TechnicalCredentialRepository
        (HelpTechContext context) :
        BaseRepository<TechnicalCredential>(context),
        ITechnicalCredentialRepository
    {
        public async Task<string?> FindByTechnicalIdAsync
            (int technicalId)
        {
            Task<TechnicalCredential?> queryAsync = new(() =>
            {
                return
                (from tc in Context.Set<TechnicalCredential>().ToList()
                 join te in Context.Set<Technical>().ToList()
                 on tc.TechnicalsId equals te.Id
                 where te.Id == technicalId &&
                 te.State == "ACTIVO"
                 select tc).FirstOrDefault();
            });

            queryAsync.Start();

            var result = await queryAsync;

            if (result is null)
                return null;

            return result.Code;
        }
    }
}