using HelpTechService.Interaction.Application.Internal.OutboundServices.ACL;
using HelpTechService.Interaction.Domain.Model.Commands.Chat;
using HelpTechService.Interaction.Domain.Repositories;
using HelpTechService.Interaction.Domain.Services.Chat;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Interaction.Application.Internal.CommandServices
{
    internal class ChatCommandService
        (IChatRepository chatRepository,
        IUnitOfWork unitOfWork,
        ExternalIamService externalIamService) :
        IChatCommandService
    {
        public async Task<bool> Handle
            (SendMessageCommand command)
        {
            try
            {
                if (await externalIamService
                    .ExistsTechnicalById
                    (Convert.ToInt32(command
                    .TechnicalId.ToString()))
                    is false &&
                    await externalIamService
                    .ExistsConsumerById
                    (Convert.ToInt32(command
                    .ConsumerId.ToString()))
                    is false)
                    return false;

                await chatRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}