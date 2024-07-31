using HelpTechService.IAM.Domain.Model.Queries.Consumer;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.Consumer;

namespace HelpTechService.IAM.Application.Internal.QueryServices
{
    internal class ConsumerQueryService
        (IConsumerRepository consumerRepository) :
        IConsumerQueryService
    {
        public async Task<bool> Handle
            (GetConsumerByIdQuery query) =>
            await consumerRepository
            .FindByIdAsync(query.Id) !=
            null;
    }
}