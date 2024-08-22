using HelpTechService.Attention.Domain.Model.ValueObjects.Job;

namespace HelpTechService.Attention.Domain.Model.Commands.Job
{
    public record RegisterRequestJobCommand
        (int AgendaId, string ConsumerId,
        string Address, string Description,
        EJobState JobState);
}