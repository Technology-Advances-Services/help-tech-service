using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.Interaction.Domain.Model.Queries.ChatMember;
using HelpTechService.Interaction.Domain.Repositories;
using HelpTechService.Interaction.Domain.Services.ChatMember;

namespace HelpTechService.Interaction.Application.Internal.QueryServices
{
    internal class ChatMemberQueryService
        (IChatMemberRepository chatMemberRepository) :
        IChatMemberQueryService
    {
        public async Task<IEnumerable<ChatMember>> Handle
            (GetChatMembersByTechnicalIdQuery query) =>
            await chatMemberRepository
            .FindByTechnicalIdAsync
            (int.Parse(query.TechnicalId
                .TrimStart('0')));

        public async Task<IEnumerable<ChatMember>> Handle
            (GetChatMembersByConsumerIdQuery query) =>
            await chatMemberRepository
            .FindByConsumerIdAsync
            (int.Parse(query.ConsumerId
                .TrimStart('0')));
    }
}