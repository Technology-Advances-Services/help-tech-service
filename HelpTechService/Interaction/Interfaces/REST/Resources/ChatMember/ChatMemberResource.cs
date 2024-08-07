namespace HelpTechService.Interaction.Interfaces.REST.Resources.ChatMember
{
    public record ChatMemberResource
        (int ChatRoomId, int? TechnicalId,
        int? ConsumerId);
}