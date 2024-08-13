using HelpTechService.Interaction.Domain.Model.Commands.Chat;
using HelpTechService.Interaction.Interfaces.REST.Resources.Chat;

namespace HelpTechService.Interaction.Interfaces.REST.Transform.Chat
{
    public class SendMessageCommandFromResourceAssembler
    {
        public static SendMessageCommand ToCommandFromResource
            (SendMessageResource resource) =>
            resource.Sender switch
            {
               "TECNICO" => new(resource.ChatRoomId,
                   resource.PersonId, null, resource.Message),

               "CONSUMIDOR" => new(resource.ChatRoomId, null,
                   resource.PersonId, resource.Message),

               _ => throw new Exception("The sender does not exist!")
            };
    }
}