using HelpTechService.Attention.Domain.Model.Queries.Agenda;

namespace HelpTechService.Attention.Domain.Services.Agenda
{
    public interface IAgendaQueryService
    {
        Task<Model.Entities.Agenda?> Handle
            (GetAgendaByTechnicalIdQuery query);
    }
}