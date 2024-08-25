using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using HelpTechService.Subscription.Domain.Model.Queries.Membership;
using HelpTechService.Subscription.Domain.Services.Membership;
using HelpTechService.Subscription.Interfaces.REST.Transform.Membership;

namespace HelpTechService.Subscription.Interfaces.REST
{
    [Route("api/memberships/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public class MembershipsController
        (IMembershipQueryService membershipQueryService) :
        ControllerBase
    {
        [Route("all-memberships")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllMemberships()
        {
            var memberships = await membershipQueryService
                .Handle(new GetAllMembershipsQuery());

            var membershipsResource = memberships.Select
                (MembershipResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(membershipsResource);
        }

        [Route("membership-by-id")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> MembershipById
            ([FromQuery] int id)
        {
            var membership = await membershipQueryService
                .Handle(new GetMembershipByIdQuery(id));

            if (membership is null)
                return BadRequest();

            var membershipResource = MembershipResourceFromEntityAssembler
                .ToResourceFromEntity(membership);

            return Ok(membershipResource);
        }
    }
}