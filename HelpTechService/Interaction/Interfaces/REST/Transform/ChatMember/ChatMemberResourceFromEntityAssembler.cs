using HelpTechService.Interaction.Interfaces.REST.Resources.ChatMember;

namespace HelpTechService.Interaction.Interfaces.REST.Transform.ChatMember
{
    public class ChatMemberResourceFromEntityAssembler
    {
        public static ChatMemberResource ToResourceFromEntity
            (Domain.Model.Aggregates.ChatMember entity) =>
            new(entity.ChatsRoomsId, entity.TechnicalsId,
                entity.ConsumersId);
    }
}