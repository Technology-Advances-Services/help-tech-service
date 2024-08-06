using HelpTechService.Interaction.Domain.Model.Commands.Chat;

namespace HelpTechService.Interaction.Domain.Services.Chat
{
    public interface IChatCommandService
    {
        Task<bool> Handle
            (SendMessageCommand command);
    }
}