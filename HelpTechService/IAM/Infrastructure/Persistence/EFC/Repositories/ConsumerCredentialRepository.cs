using Microsoft.EntityFrameworkCore;
using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    internal class ConsumerCredentialRepository
        (HelpTechContext context) :
        BaseRepository<ConsumerCredential>(context),
        IConsumerCredentialRepository
    {
        public async Task<string?> FindByConsumerIdAsync
            (int consumerId)
        {
            var result = await
                (from cc in Context.Set<ConsumerCredential>()
                 join co in Context.Set<Consumer>()
                 on cc.ConsumersId equals consumerId
                 where co.State == "ACTIVO"
                 select cc)
                 .AsNoTrackingWithIdentityResolution()
                 .FirstOrDefaultAsync();

            return result?.Code;
        }
    }
}