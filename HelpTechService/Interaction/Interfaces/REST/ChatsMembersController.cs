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
        [Route("chats-members-by-technical")]
        [HttpGet]
        public async Task<IActionResult> GetChatsMembersByTechnicalId
            ([FromQuery] int technicalId)
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
        public async Task<IActionResult> GetChatsMembersByConsumerId
            ([FromQuery] int consumerId)
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