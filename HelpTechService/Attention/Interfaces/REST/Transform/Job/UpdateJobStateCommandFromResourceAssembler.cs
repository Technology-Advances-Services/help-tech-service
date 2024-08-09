using HelpTechService.Attention.Domain.Model.Commands.Job;
using HelpTechService.Attention.Domain.Model.ValueObjects.Job;
using HelpTechService.Attention.Interfaces.REST.Resources.Job;

namespace HelpTechService.Attention.Interfaces.REST.Transform.Job
{
    public class UpdateJobStateCommandFromResourceAssembler
    {
        public static UpdateJobStateCommand ToCommandFromResource
            (UpdateJobStateResource resource) =>
            new(resource.Id, Enum.Parse<EJobState>
                (resource.JobState));
    }
}