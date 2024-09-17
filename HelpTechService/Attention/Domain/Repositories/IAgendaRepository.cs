using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Attention.Domain.Repositories
{
    public interface IAgendaRepository :
        IBaseRepository<Agenda>
    {
        Task<Agenda?> FindByTechnicalIdAsync
            (int technicalId);
    }
}