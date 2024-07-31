using HelpTechService.IAM.Domain.Model.Commands.Technical;

namespace HelpTechService.IAM.Domain.Services.Technical
{
    public interface ITechnicalCommandService
    {
        Task<bool> Handle
            (RegisterTechnicalCommand command);
    }
}