﻿using Microsoft.EntityFrameworkCore;
using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Attention.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Attention.Infrastructure.Persistence.EFC.Repositories
{
    internal class AgendaRepository
        (HelpTechContext context) :
        BaseRepository<Agenda>(context),
        IAgendaRepository
    {
        public async Task<Agenda?> FindByTechnicalIdAsync
            (int technicalId) => await Context.Set<Agenda>()
            .Where(a => a.TechnicalsId == technicalId)
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync();
    }
}