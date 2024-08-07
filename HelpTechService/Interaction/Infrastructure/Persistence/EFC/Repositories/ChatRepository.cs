using Microsoft.EntityFrameworkCore;
using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.Interaction.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Interaction.Infrastructure.Persistence.EFC.Repositories
{
    internal class ChatRepository
        (HelpTechContext context) :
        BaseRepository<Chat>(context),
        IChatRepository
    {
        public async Task<IEnumerable<Chat>> FindByChatRoomIdAsync
            (int chatRoomId) => await Context.Set<Chat>()
            .Where(c => c.ChatsRoomsId == chatRoomId)
            .ToListAsync();
    }
}