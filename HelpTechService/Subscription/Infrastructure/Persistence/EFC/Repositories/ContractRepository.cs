using Microsoft.EntityFrameworkCore;
using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.Subscription.Domain.Model.Aggregates;
using HelpTechService.Subscription.Domain.Model.ValueObjects.Contract;
using HelpTechService.Subscription.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Subscription.Infrastructure.Persistence.EFC.Repositories
{
    internal class ContractRepository
        (HelpTechContext context) :
        BaseRepository<Contract>(context),
        IContractRepository
    {
        private async Task UpdateAutomaticContractStateAsync
            (int personId)
        {
            await Context.Set<Contract>()
                .Where(c => c.TechnicalsId == personId ||
                c.ConsumersId == personId &&
                c.FinalDate >= DateTime.Now &&
                c.State == "VIGENTE")
                .ExecuteUpdateAsync(c => c
                .SetProperty(u => u.State, EContractState.VENCIDO.ToString()));
        }

        public async Task<bool> UpdateContractStateAsync
            (int id, EContractState contractState) =>
            await Context.Set<Contract>()
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(c => c
            .SetProperty(u => u.State, contractState.ToString()))
            > 0;

        public async Task<Contract?> FindByTechnicalIdAsync
            (int technicalId)
        {
            await UpdateAutomaticContractStateAsync
                (technicalId);

            Task<Contract?> queryAsync = new(() =>
            {
                return
                (from co in Context.Set<Contract>()
                 join te in Context.Set<Technical>()
                 on co.TechnicalsId equals technicalId
                 where co.State == "VIGENTE" &&
                 te.State == "ACTIVO"
                 select co)
                 .FirstOrDefault();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<Contract?> FindByConsumerIdAsync
            (int consumerId)
        {
            await UpdateAutomaticContractStateAsync
                (consumerId);

            Task<Contract?> queryAsync = new(() =>
            {
                return
                (from co in Context.Set<Contract>()
                 join cs in Context.Set<Consumer>()
                 on co.ConsumersId equals consumerId
                 where co.State == "VIGENTE" &&
                 cs.State == "ACTIVO"
                 select co)
                 .FirstOrDefault();
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}