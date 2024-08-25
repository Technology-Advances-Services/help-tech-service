using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Interaction.Domain.Repositories
{
    public interface IChatMemberRepository :
        IBaseRepository<ChatMember>
    {
        Task<ChatMember?> FindByChatRoomIdAsync
            (int chatRoomId);

        Task<IEnumerable<ChatMember>> FindByTechnicalIdAsync
            (int technicalId);

        Task<IEnumerable<ChatMember>> FindByConsumerIdAsync
            (int consumerId);
    }
}