using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    public class ConsumerCredentialRepository
        (HelpTechContext context) :
        BaseRepository<ConsumerCredential>(context),
        IConsumerCredentialRepository
    {
        public async Task<string?> FindByConsumerIdAsync
            (int consumerId)
        {
            Task<ConsumerCredential?> queryAsync = new(() =>
            {
                return
                (from cc in Context.Set<ConsumerCredential>().ToList()
                 join co in Context.Set<Consumer>().ToList()
                 on cc.ConsumersId equals co.Id
                 where co.Id == consumerId &&
                 co.State == "ACTIVO"
                 select cc).FirstOrDefault();
            });

            queryAsync.Start();

            var result = await queryAsync;

            if (result is null)
                return null;

            return result.Code;
        }
    }
}