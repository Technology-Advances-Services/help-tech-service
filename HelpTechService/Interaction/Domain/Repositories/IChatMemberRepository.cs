using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Interaction.Domain.Repositories
{
    public interface IChatMemberRepository :
        IBaseRepository<ChatMember>
    {
        Task<IEnumerable<ChatMember>> FindByTechnicalIdAsync
            (int technicalId);

        Task<IEnumerable<ChatMember>> FindByConsumerIdAsync
            (int consumerId);
    }
}