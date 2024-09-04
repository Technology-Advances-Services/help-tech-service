using HelpTechService.IAM.Domain.Model.Commands.TechnicalCredential;

namespace HelpTechService.IAM.Domain.Services.TechnicalCredential
{
    public interface ITechnicalCredentialCommandService
    {
        Task<bool> Handle
            (AddTechnicalCredentialCommand command);

        Task<bool> Handle
            (UpdateTechnicalCredentialCommand command);
    }
}