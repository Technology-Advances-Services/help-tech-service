using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Domain.Repositories
{
    public interface IConsumerRepository :
        IBaseRepository<Consumer>
    { }
}