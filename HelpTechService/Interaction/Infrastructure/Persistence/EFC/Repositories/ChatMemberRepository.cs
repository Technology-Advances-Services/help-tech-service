using Microsoft.EntityFrameworkCore;
using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.Interaction.Domain.Model.Entities;
using HelpTechService.Interaction.Domain.Model.ValueObjects;
using HelpTechService.Interaction.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Interaction.Infrastructure.Persistence.EFC.Repositories
{
    internal class ChatMemberRepository
        (HelpTechContext context) :
        BaseRepository<ChatMember>(context),
        IChatMemberRepository
    {
        public async Task<ChatMember?> FindByChatRoomIdAsync
            (int chatRoomId) =>
            await (from cm in Context.Set<ChatMember>()
                   join cr in Context.Set<ChatRoom>()
                   on cm.ChatsRoomsId equals cr.Id
                   where cm.ChatsRoomsId == chatRoomId &&
                   cr.State == EChatRoomState.ACTIVO.ToString()
                   select new ChatMember
                   (
                      cm.ChatsRoomsId,
                      cm.TechnicalsId,
                      cm.ConsumersId,
                      cm.Technical,
                      cm.Consumer
                   )).AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<ChatMember>> FindByTechnicalIdAsync
            (int technicalId) =>
            await (from cm in Context.Set<ChatMember>()
                   join cr in Context.Set<ChatRoom>()
                   on cm.ChatsRoomsId equals cr.Id
                   where cm.TechnicalsId == technicalId &&
                   cr.State == EChatRoomState.ACTIVO.ToString()
                   select new ChatMember
                   (
                      cm.ChatsRoomsId,
                      cm.TechnicalsId,
                      cm.ConsumersId,
                      cm.Technical,
                      cm.Consumer
                   )).AsNoTrackingWithIdentityResolution()
            .ToListAsync();

        public async Task<IEnumerable<ChatMember>> FindByConsumerIdAsync
            (int consumerId) =>
            await (from cm in Context.Set<ChatMember>()
                   join cr in Context.Set<ChatRoom>()
                   on cm.ChatsRoomsId equals cr.Id
                   where cm.ConsumersId == consumerId &&
                   cr.State == EChatRoomState.ACTIVO.ToString()
                   select new ChatMember
                   (
                      cm.ChatsRoomsId,
                      cm.TechnicalsId,
                      cm.ConsumersId,
                      cm.Technical,
                      cm.Consumer
                   )).AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    }
}