using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.Interaction.Domain.Model.Entities;
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
            (int chatRoomId)
        {
            Task<IEnumerable<Chat>> queryAsync = new(() =>
            {
                return
                [.. (from ch in Context.Set<Chat>()
                 join cr in Context.Set<ChatRoom>()
                 on ch.ChatsRoomsId equals chatRoomId
                 where cr.State == "ACTIVO"
                 select ch)];
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}