using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Attention.Domain.Repositories
{
    public interface IReviewRepository :
        IBaseRepository<Review>
    {
        Task<IEnumerable<Review>> FindByTechnicalIdAsync
            (int technicalId);
    }
}