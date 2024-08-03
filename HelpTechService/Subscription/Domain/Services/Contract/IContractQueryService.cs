using HelpTechService.Subscription.Domain.Model.Queries.Contract;

namespace HelpTechService.Subscription.Domain.Services.Contract
{
    public interface IContractQueryService
    {
        Task<Model.Aggregates.Contract?> Handle
            (GetContractByTechnicalIdQuery query);

        Task<Model.Aggregates.Contract?> Handle
            (GetContractByConsumerIdQuery query);
    }
}