using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.Interaction.Domain.Model.Commands.Chat;
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
        
        public Chat()
        {
            this.ChatsRoomsId = 0;
            this.TechnicalsId = 0;
            this.ConsumersId = 0;
            this.Message = string.Empty;
        }
        public Chat
            (int chatRoomId, int? technicalId,
            int? consumerId, string message)
        {
            this.ChatsRoomsId = chatRoomId;
            this.TechnicalsId = technicalId;
            this.ConsumersId = consumerId;
            this.ShippingDate = DateTime.UtcNow;
            this.Message = message;
        }
        public Chat
            (SendMessageCommand command)
        {
            this.ChatsRoomsId = command.ChatRoomId;
            this.TechnicalsId = command.TechnicalId;
            this.ConsumersId = command.ConsumerId;
            this.ShippingDate = DateTime.UtcNow;
            this.Message = command.Message;
        }
    }
}