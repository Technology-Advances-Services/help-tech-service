using HelpTechService.Attention.Domain.Model.Aggregates;
using HelpTechService.Attention.Domain.Model.Queries.Job;
using HelpTechService.Attention.Domain.Repositories;
using HelpTechService.Attention.Domain.Services.Job;

namespace HelpTechService.Attention.Application.Internal.QueryServices
{
    internal class JobQueryService
        (IJobRepository jobRepository) :
        IJobQueryService
    {
        public Task<Job?> Handle
            (GetJobByIdQuery query) =>
            jobRepository.FindByIdAsync
            (query.Id);

        public async Task<IEnumerable<Job>> Handle
            (GetJobsByTechnicalIdQuery query) =>
            await jobRepository
            .FindByTechnicalIdAsync
            (query.TechnicalId);

        public async Task<IEnumerable<Job>> Handle
            (GetJobsByConsumerIdQuery query) =>
            await jobRepository
            .FindByConsumerIdAsync
            (query.ConsumerId);

        public async Task<IEnumerable<Job>> Handle
            (GetJobsByTechnicalIdAndStateQuery query) =>
            await jobRepository
            .FindByTechnicalIdAndStateAsync
            (query.TechnicalId, query.JobState);

        public async Task<IEnumerable<Job>> Handle
            (GetJobsByConsumerIdAndStateQuery query) =>
            await jobRepository
            .FindByConsumerIdAndStateAsync
            (query.ConsumerId, query.JobState);
    }
}