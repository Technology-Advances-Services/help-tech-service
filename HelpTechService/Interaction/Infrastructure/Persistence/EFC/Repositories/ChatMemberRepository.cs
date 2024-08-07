using Microsoft.EntityFrameworkCore;
using HelpTechService.Interaction.Domain.Model.Aggregates;
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
            (int technicalId) => await Context.Set<ChatMember>()
            .Where(c => c.TechnicalsId == technicalId)
            .ToListAsync();

        public async Task<IEnumerable<ChatMember>> FindByConsumerIdAsync
            (int consumerId) => await Context.Set<ChatMember>()
            .Where(c => c.ConsumersId == consumerId)
            .ToListAsync();
    }
}