using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    public class ConsumerRepository
        (HelpTechContext context) :
        BaseRepository<Consumer>(context),
        IConsumerRepository
    { }
}