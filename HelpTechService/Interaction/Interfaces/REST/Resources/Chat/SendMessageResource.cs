namespace HelpTechService.Interaction.Interfaces.REST.Resources.Chat
{
    public record SendMessageResource
        (int ChatRoomId, int? TechnicalId,
        int? ConsumerId, string Message);
}