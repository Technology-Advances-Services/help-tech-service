using HelpTechService.IAM.Domain.Model.Commands.Consumer;

namespace HelpTechService.IAM.Domain.Services.Consumer
{
    public interface IConsumerCommandService
    {
        Task<bool> Handle
            (RegisterConsumerCommand command);
    }
}