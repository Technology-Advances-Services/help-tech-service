namespace HelpTechService.Interaction.Interfaces.REST.Resources.Chat
{
    public record ChatResource
        (int ChatRoomId, int? TechnicalId,
        int? ConsumerId, DateTime ShippingDate,
        string Message);
}