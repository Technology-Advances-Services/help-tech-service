using HelpTechService.Attention.Domain.Model.Aggregates;
using HelpTechService.Attention.Domain.Model.ValueObjects.Job;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Attention.Domain.Repositories
{
    public interface IJobRepository :
        IBaseRepository<Job>
    {
        Task<bool> AssignJobDetailAsync
            (int id, DateTime workDate,
            decimal time, decimal laborBudget,
            decimal materialBudget);

        Task<bool> UpdateJobStateAsync
            (int id, EJobState jobState);

        Task<IEnumerable<Job>> FindByTechnicalIdAsync
            (int technicalId);

        Task<IEnumerable<Job>> FindByConsumerIdAsync
            (int consumerId);

        Task<IEnumerable<Job>> FindByTechnicalIdAndStateAsync
            (int technicalId, EJobState jobState);

        Task<IEnumerable<Job>> FindByConsumerIdAndStateAsync
            (int consumerId, EJobState jobState);
    }
}