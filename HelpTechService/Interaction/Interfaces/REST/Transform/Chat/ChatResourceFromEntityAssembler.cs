using HelpTechService.Interaction.Interfaces.REST.Resources.Chat;

namespace HelpTechService.Interaction.Interfaces.REST.Transform.Chat
{
    public class ChatResourceFromEntityAssembler
    {
        public static ChatResource ToResourceFromEntity
            (Domain.Model.Aggregates.Chat entity) =>
            new(entity.ChatsRoomsId, entity.TechnicalsId,
                entity.ConsumersId, entity.ShippingDate,
                entity.Message);
    }
}