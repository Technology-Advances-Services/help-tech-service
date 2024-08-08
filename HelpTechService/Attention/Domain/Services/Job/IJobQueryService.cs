using HelpTechService.Attention.Domain.Model.Queries.Job;

namespace HelpTechService.Attention.Domain.Services.Job
{
    public interface IJobQueryService
    {
        Task<Model.Aggregates.Job?> Handle
            (GetJobByIdQuery query);

        Task<IEnumerable<Model.Aggregates.Job>> Handle
            (GetJobsByTechnicalIdQuery query);

        Task<IEnumerable<Model.Aggregates.Job>> Handle
            (GetJobsByConsumerIdQuery query);

        Task<IEnumerable<Model.Aggregates.Job>> Handle
            (GetJobsByTechnicalIdAndStateQuery query);

        Task<IEnumerable<Model.Aggregates.Job>> Handle
            (GetJobsByConsumerIdAndStateQuery query);
    }
}