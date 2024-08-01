using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    internal class CriminalRecordRepository
        (HelpTechContext context) :
        BaseRepository<CriminalRecord>(context),
        ICriminalRecordRepository
    {
        public async Task<CriminalRecord?> FindByTechnicalIdAsync
            (int technicalId)
        {
            Task<CriminalRecord?> queryAsync = new(() =>
            {
                return
                (from cr in Context.Set<CriminalRecord>().ToList()
                 join te in Context.Set<Technical>().ToList()
                 on cr.TechnicalsId equals te.Id
                 where te.Id == technicalId &&
                 te.State == "ACTIVO"
                 select cr).FirstOrDefault();
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}