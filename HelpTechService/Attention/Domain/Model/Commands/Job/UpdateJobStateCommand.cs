using HelpTechService.Attention.Domain.Model.ValueObjects.Job;

namespace HelpTechService.Attention.Domain.Model.Commands.Job
{
    public record UpdateJobStateCommand
        (int Id, EJobState JobState);
}