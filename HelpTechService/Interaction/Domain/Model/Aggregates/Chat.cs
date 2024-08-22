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
            (int chatRoomId, string? technicalId,
            string? consumerId, string message)
        {
            this.ChatsRoomsId = chatRoomId;
            this.TechnicalsId = int.TryParse
                (technicalId, out int technicalsId) != false ?
                int.Parse(technicalsId.ToString().TrimStart('0')) : null;
            this.ConsumersId = int.TryParse
                (consumerId, out int consumersId) != false ?
                int.Parse(consumersId.ToString().TrimStart('0')) : null;
            this.ShippingDate = DateTime.Now;
            this.Message = message;
        }
        public Chat
            (SendMessageCommand command)
        {
            this.ChatsRoomsId = command.ChatRoomId;
            this.TechnicalsId = int.TryParse
                (command.TechnicalId, out int technicalsId) != false ?
                int.Parse(technicalsId.ToString().TrimStart('0')) : null;
            this.ConsumersId = int.TryParse
                (command.ConsumerId, out int consumersId) != false ?
                int.Parse(consumersId.ToString().TrimStart('0')) : null;
            this.ShippingDate = DateTime.Now;
            this.Message = command.Message;
        }
    }
}