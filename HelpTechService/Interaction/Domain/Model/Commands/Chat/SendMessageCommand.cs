namespace HelpTechService.Interaction.Domain.Model.Commands.Chat
{
    public record SendMessageCommand
        (int ChatRoomId, int TechnicalId,
        int ConsumerId, string Message);
}