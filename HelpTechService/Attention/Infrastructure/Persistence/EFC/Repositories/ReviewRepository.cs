using Microsoft.EntityFrameworkCore;
using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Attention.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Attention.Infrastructure.Persistence.EFC.Repositories
{
    public class ReviewRepository
        (HelpTechContext context) :
        BaseRepository<Review>(context),
        IReviewRepository
    {
        public async Task<IEnumerable<Review>> FindByTechnicalIdAsync
            (int technicalId) => await Context.Set<Review>()
            .Where(r => r.TechnicalsId == technicalId &&
            r.State == "PUBLICADO").ToListAsync();
    }
}