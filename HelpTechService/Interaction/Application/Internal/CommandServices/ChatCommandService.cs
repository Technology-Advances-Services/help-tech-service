using HelpTechService.Interaction.Domain.Model.Commands.Chat;
using HelpTechService.Interaction.Domain.Repositories;
using HelpTechService.Interaction.Domain.Services.Chat;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Interaction.Application.Internal.CommandServices
{
    internal class ChatCommandService
        (IChatRepository chatRepository,
        IUnitOfWork unitOfWork) :
        IChatCommandService
    {
        public async Task<bool> Handle
            (SendMessageCommand command)
        {
            try
            {
                await chatRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}