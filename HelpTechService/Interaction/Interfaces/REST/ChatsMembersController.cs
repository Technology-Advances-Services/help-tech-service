using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using HelpTechService.Interaction.Domain.Services.ChatMember;
using HelpTechService.Interaction.Domain.Model.Queries.ChatMember;
using HelpTechService.Interaction.Interfaces.REST.Transform.ChatMember;

namespace HelpTechService.Interaction.Interfaces.REST
{
    [Route("api/chatsmembers")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize("TECNICO", "CONSUMIDOR")]
    public class ChatsMembersController
        (IChatMemberQueryService chatMemberQueryService) :
        ControllerBase
    {
        [Route("chat-member-by-chat-room")]
        [HttpGet]
        public async Task<IActionResult> ChatMemberByChatRoom
            ([FromQuery] int chatRoomId)
        {
            var chatMember = await chatMemberQueryService
                .Handle(new GetChatMemberByChatRoomIdQuery
                (chatRoomId));

            if (chatMember is null)
                return BadRequest();

            var chatMemberResource = ChatMemberResourceFromEntityAssembler
                .ToResourceFromEntity(chatMember);

            return Ok(chatMemberResource);
        }

        [Route("chats-members-by-technical")]
        [HttpGet]
        public async Task<IActionResult> ChatsMembersByTechnical
            ([FromQuery] string technicalId)
        {
            var chatsMembers = await chatMemberQueryService
                .Handle(new GetChatMembersByTechnicalIdQuery
                (technicalId));

            var chatsMembersResource = chatsMembers.Select
                (ChatMemberResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(chatsMembersResource);
        }

        [Route("chats-members-by-consumer")]
        [HttpGet]
        public async Task<IActionResult> ChatsMembersByConsumer
            ([FromQuery] string consumerId)
        {
            var chatsMembers = await chatMemberQueryService
                .Handle(new GetChatMembersByConsumerIdQuery
                (consumerId));

            var chatsMembersResource = chatsMembers.Select
                (ChatMemberResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(chatsMembersResource);
        }
    }
}