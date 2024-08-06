using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Interaction.Domain.Repositories
{
    public interface IChatRepository :
        IBaseRepository<Chat>
    {
        Task<IEnumerable<Chat>> FindByChatRoomIdAsync
            (int chatRoomId);
    }
}