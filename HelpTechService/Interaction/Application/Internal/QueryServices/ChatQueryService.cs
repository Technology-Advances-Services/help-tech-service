using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.Interaction.Domain.Model.Queries.Chat;
using HelpTechService.Interaction.Domain.Repositories;
using HelpTechService.Interaction.Domain.Services.Chat;

namespace HelpTechService.Interaction.Application.Internal.QueryServices
{
    internal class ChatQueryService
        (IChatRepository chatRepository) :
        IChatQueryService
    {
        public async Task<IEnumerable<Chat>> Handle
            (GetChatByChatRoomIdQuery query) =>
            await chatRepository
            .FindByChatRoomIdAsync
            (query.ChatRoomId);
    }
}