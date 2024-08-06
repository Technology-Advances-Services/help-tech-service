using HelpTechService.Interaction.Domain.Model.Queries.ChatMember;

namespace HelpTechService.Interaction.Domain.Services.ChatMember
{
    public interface IChatMemberQueryService
    {
        Task<IEnumerable<Model.Aggregates.ChatMember>> Handle
            (GetChatMembersByTechnicalIdQuery query);

        Task<IEnumerable<Model.Aggregates.ChatMember>> Handle
            (GetChatMembersByConsumerIdQuery query);
    }
}