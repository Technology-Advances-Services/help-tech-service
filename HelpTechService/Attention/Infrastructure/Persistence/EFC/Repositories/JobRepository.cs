using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
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
            .SetProperty(u => u.WorkDate, workDate)
            .SetProperty(u => u.Time, time)
            .SetProperty(u => u.LaborBudget, laborBudget)
            .SetProperty(u => u.MaterialBudget, materialBudget))
            > 0;

        public async Task<bool> UpdateJobStateAsync
            (int id, EJobState jobState) =>
            await Context.Set<Job>().Where(j => j.Id == id)
            .ExecuteUpdateAsync(j => j
            .SetProperty(u => u.State, Regex.Replace(jobState
                .ToString(), "([A-Z])", " $1").Trim())) > 1;

        public async Task<IEnumerable<Job>> FindByTechnicalIdAsync
            (int technicalId)
        {
            Task<IEnumerable<Job>> queryAsync = new(() =>
            {
                return
                (from jb in Context.Set<Job>().ToList()
                 join ag in Context.Set<Agenda>().ToList()
                 on jb.AgendasId equals ag.Id
                 join te in Context.Set<Technical>().ToList()
                 on ag.TechnicalsId equals technicalId
                 select jb).ToList();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<IEnumerable<Job>> FindByConsumerIdAsync
            (int consumerId) => await Context.Set<Job>()
            .Where(j => j.ConsumersId == consumerId)
            .ToListAsync();

        public async Task<IEnumerable<Job>> FindByTechnicalIdAndStateAsync
            (int technicalId, EJobState jobState)
        {
            Task<IEnumerable<Job>> queryAsync = new(() =>
            {
                return
                (from jb in Context.Set<Job>().ToList()
                 join ag in Context.Set<Agenda>().ToList()
                 on jb.AgendasId equals ag.Id
                 join te in Context.Set<Technical>().ToList()
                 on ag.TechnicalsId equals technicalId
                 where te.State == Regex.Replace(jobState
                 .ToString(), "([A-Z])", " $1").Trim()
                 select jb).ToList();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<IEnumerable<Job>> FindByConsumerIdAndStateAsync
            (int consumerId, EJobState jobState) =>
            await Context.Set<Job>()
            .Where(j => j.ConsumersId == consumerId &&
            j.State == Regex.Replace(jobState
                .ToString(), "([A-Z])", " $1")
                .Trim())
            .ToListAsync();
    }
}