using HelpTechService.IAM.Domain.Model.Queries.Consumer;

namespace HelpTechService.IAM.Domain.Services.Consumer
{
    public interface IConsumerQueryService
    {
        Task<Model.Aggregates.Consumer?> Handle
            (GetConsumerByIdQuery query);
    }
}