using HelpTechService.Subscription.Domain.Model.Queries.Contract;

namespace HelpTechService.Subscription.Domain.Services.Contract
{
    public interface IContractQueryService
    {
        Task<IEnumerable<Model.Aggregates.Contract>> Handle
            (GetContractsByTechnicalIdQuery query);
    }
}