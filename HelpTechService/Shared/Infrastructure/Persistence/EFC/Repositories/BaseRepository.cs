using Microsoft.EntityFrameworkCore;
using HelpTechService.Shared.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public abstract class BaseRepository
        <TEntity>(HelpTechContext context) :
        IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly HelpTechContext Context = context;

        public async Task AddAsync(TEntity entity) =>
            await Context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity) =>
            Context.Set<TEntity>().Update(entity);

        public void Remove(TEntity entity) =>
            Context.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> ListAsync() =>
            await Context.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> FindByIdAsync
            (int id) => await Context.Set<TEntity>()
            .FindAsync(id);
    }
}