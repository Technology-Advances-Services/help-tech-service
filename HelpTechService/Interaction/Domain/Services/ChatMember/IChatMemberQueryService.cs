using HelpTechService.Interaction.Domain.Model.Queries.ChatMember;

namespace HelpTechService.Interaction.Domain.Services.ChatMember
{
    public interface IChatMemberQueryService
    {
        Task<Model.Aggregates.ChatMember?> Handle
            (GetChatMemberByChatRoomIdQuery query);

        Task<IEnumerable<Model.Aggregates.ChatMember>> Handle
            (GetChatMembersByTechnicalIdQuery query);

        Task<IEnumerable<Model.Aggregates.ChatMember>> Handle
            (GetChatMembersByConsumerIdQuery query);
    }
}