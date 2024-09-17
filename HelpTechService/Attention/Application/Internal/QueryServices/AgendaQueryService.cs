using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Attention.Domain.Model.Queries.Agenda;
using HelpTechService.Attention.Domain.Repositories;
using HelpTechService.Attention.Domain.Services.Agenda;

namespace HelpTechService.Attention.Application.Internal.QueryServices
{
    public class AgendaQueryService
        (IAgendaRepository agendaRepository) :
        IAgendaQueryService
    {
        public async Task<Agenda?> Handle
            (GetAgendaByTechnicalIdQuery query) =>
            await agendaRepository
            .FindByTechnicalIdAsync
            (int.Parse(query.TechnicalId
                .TrimStart('0')));
    }
}