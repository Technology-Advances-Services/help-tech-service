using HelpTechService.Interaction.Interfaces.REST.Resources.Chat;

namespace HelpTechService.Interaction.Interfaces.REST.Transform.Chat
{
    public class ChatResourceFromEntityAssembler
    {
        public static ChatResource ToResourceFromEntity
            (Domain.Model.Aggregates.Chat entity) =>
            new(entity.ChatsRoomsId,

                entity.TechnicalsId.HasValue &&
                entity.TechnicalsId.Value.ToString().Length == 8 ?
                entity.TechnicalsId.Value.ToString() :
                entity.TechnicalsId.HasValue ? "0" +
                entity.TechnicalsId.Value.ToString() : null,

                entity.ConsumersId.HasValue &&
                entity.ConsumersId.Value.ToString().Length == 8 ?
                entity.ConsumersId.Value.ToString() :
                entity.ConsumersId.HasValue ? "0" +
                entity.ConsumersId.Value.ToString() : null,

                entity.ShippingDate,
                entity.Message);
    }
}