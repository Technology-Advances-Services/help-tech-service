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
            (int personId, string role)
        {
            string filterField = role == "TECNICO" ?
                nameof(Contract.TechnicalsId) :
                nameof(Contract.ConsumersId);

            await Context.Set<Contract>()
                .Where(c => EF.Property<int>(c, filterField) == personId &&
                c.FinalDate <= DateTime.Now &&
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
                (technicalId, "TECNICO");

            return await
                (from co in Context.Set<Contract>()
                 join te in Context.Set<Technical>()
                 on co.TechnicalsId equals te.Id
                 where co.State == EContractState.VIGENTE.ToString() &&
                 te.Id == technicalId &&
                 te.State == "ACTIVO"
                 select co).FirstOrDefaultAsync();
        }

        public async Task<Contract?> FindByConsumerIdAsync
            (int consumerId)
        {
            await UpdateAutomaticContractStateAsync
                (consumerId, "CONSUMIDOR");

            return await
                (from ct in Context.Set<Contract>()
                 join cr in Context.Set<Consumer>()
                 on ct.ConsumersId equals cr.Id
                 where ct.State == EContractState.VIGENTE.ToString() &&
                 cr.Id == consumerId &&
                 cr.State == "ACTIVO"
                 select ct).FirstOrDefaultAsync();
        }
    }
}