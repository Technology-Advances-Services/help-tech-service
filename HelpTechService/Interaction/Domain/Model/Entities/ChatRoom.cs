using HelpTechService.Interaction.Domain.Model.Aggregates;

namespace HelpTechService.Interaction.Domain.Model.Entities
{
    public class ChatRoom
    {
        public int Id { get; }
        public DateTime RegistrationDate { get; private set; }
        public string State { get; private set; } = null!;

        public virtual ICollection<Chat> Chats { get; } = [];
    }
}