﻿using Microsoft.EntityFrameworkCore;
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
            (int technicalId) =>
            await (from cr in Context.Set<CriminalRecord>()
                   join te in Context.Set<Technical>()
                   on cr.TechnicalsId equals technicalId
                   where te.State == "ACTIVO"
                   select cr)
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync();
    }
}