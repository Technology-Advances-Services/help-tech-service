using Microsoft.EntityFrameworkCore;
using HelpTechService.Attention.Domain.Model.Aggregates;
using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Attention.Domain.Model.ValueObjects.Job;
using HelpTechService.Attention.Domain.Repositories;
using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Attention.Infrastructure.Persistence.EFC.Repositories
{
    internal class JobRepository
        (HelpTechContext context) :
        BaseRepository<Job>(context),
        IJobRepository
    {
        public async Task<bool> AssignJobDetailAsync
            (int id, DateTime workDate, decimal time,
            decimal laborBudget, decimal materialBudget) =>
            await Context.Set<Job>().Where(j => j.Id == id)
            .ExecuteUpdateAsync(j => j
            .SetProperty(u => u.AnswerDate, DateTime.Now)
            .SetProperty(u => u.WorkDate, workDate)
            .SetProperty(u => u.Time, time)
            .SetProperty(u => u.LaborBudget, laborBudget)
            .SetProperty(u => u.MaterialBudget, materialBudget)
            .SetProperty(u => u.AmountFinal, laborBudget + materialBudget))
            > 0;

        public async Task<bool> UpdateJobStateAsync
            (int id, EJobState jobState)
        {
            var newJobState = jobState == EJobState.ENPROCESO ?
                "EN PROCESO" : jobState.ToString();

            return await Context.Set<Job>().Where(j => j.Id == id)
                .ExecuteUpdateAsync(j => j
                .SetProperty(u => u.State, newJobState)) > 0;
        }

        new public async Task<Job?> FindByIdAsync(int id) =>
            await (from jo in Context.Set<Job>()
                   join ag in Context.Set<Agenda>()
                   on jo.AgendasId equals ag.Id
                   join co in Context.Set<Consumer>()
                   on jo.ConsumersId equals co.Id
                   where jo.Id == id
                   select new Job
                   (
                      jo.Id,
                      jo.AgendasId,
                      jo.ConsumersId.ToString(),
                      jo.AnswerDate,
                      jo.WorkDate,
                      jo.Address,
                      jo.Description,
                      jo.Time ?? 0,
                      jo.LaborBudget ?? 0,
                      jo.MaterialBudget ?? 0,
                      Enum.Parse<EJobState>(jo.State.Replace(" ", "")),
                      new(ag.Technical),
                      co
                   )).AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync();

        public async Task<IEnumerable<Job>> FindByTechnicalIdAsync
            (int technicalId) =>
            await (from jo in Context.Set<Job>()
                   join ag in Context.Set<Agenda>()
                   on jo.AgendasId equals ag.Id
                   join co in Context.Set<Consumer>()
                   on jo.ConsumersId equals co.Id
                   where ag.TechnicalsId == technicalId
                   select new Job
                   (
                      jo.Id,
                      jo.AgendasId,
                      jo.ConsumersId.ToString(),
                      jo.AnswerDate,
                      jo.WorkDate,
                      jo.Address,
                      jo.Description,
                      jo.Time ?? 0,
                      jo.LaborBudget ?? 0,
                      jo.MaterialBudget ?? 0,
                      Enum.Parse<EJobState>(jo.State.Replace(" ", "")),
                      new(ag.Technical),
                      co
                   )).AsNoTrackingWithIdentityResolution().ToListAsync();

        public async Task<IEnumerable<Job>> FindByConsumerIdAsync
            (int consumerId) =>
            await (from jo in Context.Set<Job>()
                   join ag in Context.Set<Agenda>()
                   on jo.AgendasId equals ag.Id
                   join co in Context.Set<Consumer>()
                   on jo.ConsumersId equals co.Id
                   where jo.ConsumersId == consumerId
                   select new Job
                   (
                      jo.Id,
                      jo.AgendasId,
                      jo.ConsumersId.ToString(),
                      jo.AnswerDate,
                      jo.WorkDate,
                      jo.Address,
                      jo.Description,
                      jo.Time ?? 0,
                      jo.LaborBudget ?? 0,
                      jo.MaterialBudget ?? 0,
                      Enum.Parse<EJobState>(jo.State.Replace(" ", "")),
                      new(ag.Technical),
                      co
                   )).AsNoTrackingWithIdentityResolution().ToListAsync();

        public async Task<IEnumerable<Job>> FindByTechnicalIdAndStateAsync
            (int technicalId, EJobState jobState)
        {
            var newJobState = jobState == EJobState.ENPROCESO ?
                "EN PROCESO" : jobState.ToString();

            return await (from jo in Context.Set<Job>()
                          join ag in Context.Set<Agenda>()
                          on jo.AgendasId equals ag.Id
                          join co in Context.Set<Consumer>()
                          on jo.ConsumersId equals co.Id
                          where jo.State == newJobState &&
                          ag.TechnicalsId == technicalId
                          select new Job
                          (
                             jo.Id,
                             jo.AgendasId,
                             jo.ConsumersId.ToString(),
                             jo.AnswerDate,
                             jo.WorkDate,
                             jo.Address,
                             jo.Description,
                             jo.Time ?? 0,
                             jo.LaborBudget ?? 0,
                             jo.MaterialBudget ?? 0,
                             Enum.Parse<EJobState>(jo.State.Replace(" ", "")),
                             new(ag.Technical),
                             co
                          )).AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        public async Task<IEnumerable<Job>> FindByConsumerIdAndStateAsync
            (int consumerId, EJobState jobState)
        {
            var newJobState = jobState == EJobState.ENPROCESO ?
                "EN PROCESO" : jobState.ToString();

            return await (from jo in Context.Set<Job>()
                          join ag in Context.Set<Agenda>()
                          on jo.AgendasId equals ag.Id
                          join co in Context.Set<Consumer>()
                          on jo.ConsumersId equals co.Id
                          where jo.State == newJobState &&
                          jo.ConsumersId == consumerId
                          select new Job
                          (
                             jo.Id,
                             jo.AgendasId,
                             jo.ConsumersId.ToString(),
                             jo.AnswerDate,
                             jo.WorkDate,
                             jo.Address,
                             jo.Description,
                             jo.Time ?? 0,
                             jo.LaborBudget ?? 0,
                             jo.MaterialBudget ?? 0,
                             Enum.Parse<EJobState>(jo.State.Replace(" ", "")),
                             new(ag.Technical),
                             co
                          )).AsNoTrackingWithIdentityResolution().ToListAsync();
        }
    }
}