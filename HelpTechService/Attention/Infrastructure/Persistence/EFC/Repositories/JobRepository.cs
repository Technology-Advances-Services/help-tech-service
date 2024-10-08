﻿using Microsoft.EntityFrameworkCore;
using HelpTechService.Attention.Domain.Model.Aggregates;
using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Attention.Domain.Model.ValueObjects.Job;
using HelpTechService.Attention.Domain.Repositories;
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

        public async Task<IEnumerable<Job>> FindByTechnicalIdAsync
            (int technicalId) =>
            await (from jo in Context.Set<Job>()
                   join ag in Context.Set<Agenda>()
                   on jo.AgendasId equals ag.Id
                   where ag.TechnicalsId == technicalId
                   select jo)
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();

        public async Task<IEnumerable<Job>> FindByConsumerIdAsync
            (int consumerId) => await Context.Set<Job>()
            .Where(j => j.ConsumersId == consumerId)
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();

        public async Task<IEnumerable<Job>> FindByTechnicalIdAndStateAsync
            (int technicalId, EJobState jobState)
        {
            var newJobState = jobState == EJobState.ENPROCESO ?
                "EN PROCESO" : jobState.ToString();

            var result = await
                (from jo in Context.Set<Job>()
                 join ag in Context.Set<Agenda>()
                 on jo.AgendasId equals ag.Id
                 where jo.State == newJobState &&
                 ag.TechnicalsId == technicalId
                 select jo)
                 .AsNoTrackingWithIdentityResolution()
                 .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Job>> FindByConsumerIdAndStateAsync
            (int consumerId, EJobState jobState)
        {
            var newJobState = jobState == EJobState.ENPROCESO ?
                "EN PROCESO" : jobState.ToString();

            return await Context.Set<Job>()
                .Where(j => j.ConsumersId == consumerId &&
                j.State == newJobState)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }
    }
}