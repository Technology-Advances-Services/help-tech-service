namespace HelpTechService.Interaction.Interfaces.REST.Resources.Chat
{
    public record SendMessageResource
        (int ChatRoomId, string PersonId,
        string Sender, string Message);
}