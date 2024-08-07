using HelpTechService.Interaction.Domain.Model.Commands.Chat;
using HelpTechService.Interaction.Interfaces.REST.Resources.Chat;

namespace HelpTechService.Interaction.Interfaces.REST.Transform.Chat
{
    public class SendMessageCommandFromResourceAssembler
    {
        public static SendMessageCommand ToCommandFromResource
            (SendMessageResource resource)
        {
            if (resource.Sender == "TECNICO")
                return new(resource.ChatRoomId,
                    resource.PersonId, null,
                    resource.Message);

            else if (resource.Sender == "CONSUMIDOR")
                return new(resource.ChatRoomId, null,
                    resource.PersonId, resource.Message);

            else
                throw new Exception("The sender does not exist!");
        }
    }
}