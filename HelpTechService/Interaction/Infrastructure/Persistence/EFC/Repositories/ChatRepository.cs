using Microsoft.EntityFrameworkCore;
using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.Interaction.Domain.Model.Entities;
using HelpTechService.Interaction.Domain.Model.ValueObjects;
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
            (int chatRoomId) =>
            await (from ch in Context.Set<Chat>()
                   join cr in Context.Set<ChatRoom>()
                   on ch.ChatsRoomsId equals cr.Id
                   where cr.Id == chatRoomId &&
                   cr.State == EChatRoomState.ACTIVO.ToString()
                   select new Chat(
                       ch.Id,
                       ch.ChatsRoomsId,
                       ch.TechnicalsId.ToString(),
                       ch.ConsumersId.ToString(),
                       ch.ShippingDate,
                       ch.Message,
                       ch.TechnicalsId == null ? null : ch.Technical,
                       ch.ConsumersId == null ? null : ch.Consumer
                   )).AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    }
}