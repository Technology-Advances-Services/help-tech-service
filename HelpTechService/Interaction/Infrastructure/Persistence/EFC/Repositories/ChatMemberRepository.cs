using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.Interaction.Domain.Model.Entities;
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
        public async Task<IEnumerable<ChatMember>> FindByTechnicalIdAsync
            (int technicalId)
        {
            Task<IEnumerable<ChatMember>> queryAsync = new(() =>
            {
                return
                [.. (from cm in Context.Set<ChatMember>()
                join cr in Context.Set<ChatRoom>()
                on cm.ChatsRoomsId equals cr.Id
                where cm.TechnicalsId == technicalId &&
                cr.State == "ACTIVO"
                select cm)];
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<IEnumerable<ChatMember>> FindByConsumerIdAsync
            (int consumerId)
        {
            Task<IEnumerable<ChatMember>> queryAsync = new(() =>
            {
                return
                [.. (from cm in Context.Set<ChatMember>()
                join cr in Context.Set<ChatRoom>()
                on cm.ChatsRoomsId equals cr.Id
                where cm.ConsumersId == consumerId &&
                cr.State == "ACTIVO"
                select cm)];
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}