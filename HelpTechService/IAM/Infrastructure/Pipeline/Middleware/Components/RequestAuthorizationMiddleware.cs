using HelpTechService.IAM.Application.Internal.OutboundServices;
using HelpTechService.IAM.Domain.Model.Queries.ConsumerCredential;
using HelpTechService.IAM.Domain.Model.Queries.TechnicalCredential;
using HelpTechService.IAM.Domain.Model.ValueObjects.Credential;
using HelpTechService.IAM.Domain.Services.ConsumerCredential;
using HelpTechService.IAM.Domain.Services.TechnicalCredential;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Components
{
    public class RequestAuthorizationMiddleware
        (RequestDelegate next)
    {
        public async Task InvokeAsync
            (HttpContext context,
            ITechnicalCredentialQueryService technicalCredentialQueryService,
            IConsumerCredentialQueryService consumerCredentialQueryService,
            ITokenService tokenService)
        {
            var allowAnonymous =
                context.Request.HttpContext
                .GetEndpoint()!.Metadata.Any(m =>
                m.GetType() == typeof
                (AllowAnonymousAttribute));

            if (allowAnonymous)
            {
                await next(context);

                return;
            }

            var token = context.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

            var tokenResult = tokenService.ValidateToken(token) ??
                throw new Exception("Invalid token!");

            dynamic? validation = null;

            if (tokenResult.Role == ECredentialRole
                .TECNICO.ToString())
                validation = await technicalCredentialQueryService.Handle
                    (new GetTechnicalCredentialByTechnicalIdAndCodeQuery
                    (tokenResult.Id, tokenResult.Code));

            else if (tokenResult.Role == ECredentialRole
                .CONSUMIDOR.ToString())
                validation = await consumerCredentialQueryService.Handle
                    (new GetConsumerCredentialByConsumerIdAndCodeQuery
                    (tokenResult.Id, tokenResult.Code));

            if (validation is null)
                throw new Exception("Invalid credentials!");

            if (validation.Result is true)
                context.Items["Credentials"] = tokenResult;

            else throw new Exception("Credentials not found!");

            await next(context);
        }
    }
}