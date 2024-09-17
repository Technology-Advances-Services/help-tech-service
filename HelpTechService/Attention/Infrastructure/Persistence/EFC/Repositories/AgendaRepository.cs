using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Attention.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelpTechService.Attention.Infrastructure.Persistence.EFC.Repositories
{
    public class AgendaRepository
        (HelpTechContext context) :
        BaseRepository<Agenda>(context),
        IAgendaRepository
    {
        public async Task<Agenda?> FindByTechnicalIdAsync
            (int technicalId) => await Context.Set<Agenda>()
            .Where(a => a.TechnicalsId == technicalId)
            .FirstOrDefaultAsync();
    }
}