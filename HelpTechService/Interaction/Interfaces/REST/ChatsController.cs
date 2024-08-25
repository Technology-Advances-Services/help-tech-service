using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using HelpTechService.Interaction.Domain.Model.Queries.Chat;
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
            var result = await chatCommandService
                .Handle(SendMessageCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("chats-by-chat-room")]
        [HttpGet]
        public async Task<IActionResult> ChatByChatRoomId
            ([FromQuery] int chatRoomId)
        {
            var chats = await chatQueryService
                .Handle(new GetChatByChatRoomIdQuery
                (chatRoomId));

            var chatsResource = chats.Select
                (ChatResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(chatsResource);
        }
    }
}