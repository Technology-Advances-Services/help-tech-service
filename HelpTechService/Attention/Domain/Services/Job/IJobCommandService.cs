using HelpTechService.Attention.Domain.Model.Commands.Job;

namespace HelpTechService.Attention.Domain.Services.Job
{
    public interface IJobCommandService
    {
        Task<bool> Handle
            (RegisterRequestJobCommand command);

        Task<bool> Handle
            (AssignJobDetailCommand command);

        Task<bool> Handle
            (UpdateJobStateCommand command)
    }
}