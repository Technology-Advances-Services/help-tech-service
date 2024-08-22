namespace HelpTechService.Interaction.Domain.Model.Commands.Chat
{
    public record SendMessageCommand
        (int ChatRoomId, string? TechnicalId,
        string? ConsumerId, string Message);
}