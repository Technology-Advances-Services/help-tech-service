using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Domain.Repositories
{
    public interface ITechnicalCredentialRepository :
        IBaseRepository<TechnicalCredential>
    {
        Task<string?> FindByTechnicalIdAsync
            (int technicalId);
    }
}