using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.Interaction.Domain.Model.Entities;

namespace HelpTechService.Interaction.Domain.Model.Aggregates
{
    public class Chat
    {
        public int Id { get; }
        public int ChatsRoomsId { get; private set; }
        public int? TechnicalsId { get; private set; }
        public int? ConsumersId { get; private set; }
        public DateTime ShippingDate { get; private set; }
        public string Message { get; private set; } = null!;

        public virtual ChatRoom ChatRoom { get; } = null!;
        public virtual Consumer? Consumer { get; }
        public virtual Technical? Technical { get; }
    }
}