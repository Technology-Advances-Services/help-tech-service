using HelpTechService.Attention.Domain.Model.ValueObjects.Job;

namespace HelpTechService.Attention.Domain.Model.Queries.Job
{
    public record GetJobsByTechnicalIdAndStateQuery
        (int TechnicalId, EJobState JobState);
}