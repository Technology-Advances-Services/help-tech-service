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
            (int.Parse(query.TechnicalId
                .TrimStart('0')));

        public async Task<IEnumerable<Job>> Handle
            (GetJobsByConsumerIdQuery query) =>
            await jobRepository
            .FindByConsumerIdAsync
            (int.Parse(query.ConsumerId
                .TrimStart('0')));

        public async Task<IEnumerable<Job>> Handle
            (GetJobsByTechnicalIdAndStateQuery query) =>
            await jobRepository
            .FindByTechnicalIdAndStateAsync
            (int.Parse(query.TechnicalId
                .TrimStart('0')),
                query.JobState);

        public async Task<IEnumerable<Job>> Handle
            (GetJobsByConsumerIdAndStateQuery query) =>
            await jobRepository
            .FindByConsumerIdAndStateAsync
            (int.Parse(query.ConsumerId
                .TrimStart('0')),
                query.JobState);
    }
}