namespace HelpTechService.Interaction.Interfaces.REST.Resources.ChatMember
{
    public record ChatMemberResource
        (int ChatRoomId, string? TechnicalId,
        string? ConsumerId);
}