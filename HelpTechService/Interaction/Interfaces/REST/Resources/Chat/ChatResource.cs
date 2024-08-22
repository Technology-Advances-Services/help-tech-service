namespace HelpTechService.Interaction.Interfaces.REST.Resources.Chat
{
    public record ChatResource
        (int ChatRoomId, string? TechnicalId,
        string? ConsumerId, DateTime ShippingDate,
        string Message);
}