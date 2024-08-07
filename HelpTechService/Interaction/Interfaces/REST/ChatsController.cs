using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using HelpTechService.Interaction.Domain.Services.Chat;
using HelpTechService.Interaction.Interfaces.REST.Resources.Chat;
using HelpTechService.Interaction.Interfaces.REST.Transform.Chat;

namespace HelpTechService.Interaction.Interfaces.REST
{
    [Route("api/chats/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize("TECNICO", "CONSUMIDOR")]
    public class ChatsController
        (IChatCommandService chatCommandService,
        IChatQueryService chatQueryService) :
        ControllerBase
    {
        [Route("send-message")]
        [HttpPost]
        public async Task<IActionResult> SendMessage
            ([FromBody] SendMessageResource resource)
        {
            var chat = await chatCommandService
                .Handle(SendMessageCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            return Ok(chat);
        }

        [Route("chats-by-chat-room")]
        [HttpGet]
        public async Task<IActionResult> GetChatByChatRoomId
            ([FromQuery] int chatRoomId)
        {
            var chats = await chatQueryService
                .Handle(new Domain.Model.Queries.Chat.GetChatByChatRoomIdQuery(chatRoomId));

            var chatsResource = chats.Select
                (ChatResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(chatsResource);
        }
    }
}