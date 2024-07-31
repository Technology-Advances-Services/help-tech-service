using HelpTechService.IAM.Domain.Model.Commands.ConsumerCredential;

namespace HelpTechService.IAM.Domain.Services.ConsumerCredential
{
    public interface IConsumerCredentialCommandService
    {
        Task<bool> Handle
            (AddConsumerCredentialCommand command);
    }
}