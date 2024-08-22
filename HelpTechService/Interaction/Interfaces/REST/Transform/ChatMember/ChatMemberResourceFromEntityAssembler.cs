using HelpTechService.Interaction.Interfaces.REST.Resources.ChatMember;

namespace HelpTechService.Interaction.Interfaces.REST.Transform.ChatMember
{
    public class ChatMemberResourceFromEntityAssembler
    {
        public static ChatMemberResource ToResourceFromEntity
            (Domain.Model.Aggregates.ChatMember entity) =>
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
                entity.ConsumersId.Value.ToString() : null);
    }
}