using HelpTechService.Shared.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork
        (HelpTechContext context) :
        IUnitOfWork
    {
        public async Task CompleteAsync() =>
            await context.SaveChangesAsync();
    }
}