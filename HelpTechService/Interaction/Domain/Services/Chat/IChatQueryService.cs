using HelpTechService.Interaction.Domain.Model.Queries.Chat;

namespace HelpTechService.Interaction.Domain.Services.Chat
{
    public interface IChatQueryService
    {
        Task<IEnumerable<Model.Aggregates.Chat>> Handle
            (GetChatByChatRoomIdQuery query);
    }
}