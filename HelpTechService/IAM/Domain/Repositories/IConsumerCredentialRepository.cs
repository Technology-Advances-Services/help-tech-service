using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Domain.Repositories
{
    public interface IConsumerCredentialRepository :
        IBaseRepository<ConsumerCredential>
    {
        Task<string?> FindByConsumerIdAsync
            (int consumerId);
    }
}