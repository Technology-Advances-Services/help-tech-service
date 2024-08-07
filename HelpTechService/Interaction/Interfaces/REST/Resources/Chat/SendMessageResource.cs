namespace HelpTechService.Interaction.Interfaces.REST.Resources.Chat
{
    public record SendMessageResource
        (int ChatRoomId, int PersonId,
        string Sender, string Message);
}