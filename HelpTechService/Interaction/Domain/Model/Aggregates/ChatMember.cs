using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.Interaction.Domain.Model.Entities;

namespace HelpTechService.Interaction.Domain.Model.Aggregates
{
    public class ChatMember
    {
        public int ChatsRoomsId { get; private set; }
        public int? TechnicalsId { get; private set; }
        public int? ConsumersId { get; private set; }

        public virtual ChatRoom ChatRoom { get; } = null!;
        public virtual Consumer? Consumer { get; }
        public virtual Technical? Technical { get; }

        public ChatMember() { }
        public ChatMember
            (int chatRoomId, int? technicalId, int? consumerId,
            Technical? technical, Consumer? consumer)
        {
            this.ChatsRoomsId = chatRoomId;
            this.TechnicalsId = technicalId;
            this.ConsumersId = consumerId;
            this.Technical = technical;
            this.Consumer = consumer;
        }
    }
}