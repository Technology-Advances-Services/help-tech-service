using HelpTechService.IAM.Application.Internal.OutboundServices;
using HelpTechService.IAM.Domain.Model.ValueObjects.Credential;
using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Components
{
    public class RequestAuthorizationMiddleware
        (RequestDelegate next)
    {
        public async Task InvokeAsync
            (HttpContext context,
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

            var token = context.Request.Headers
                .Authorization.FirstOrDefault()?.Split(" ").Last();

            var tokenResult = tokenService.ValidateToken(token) ??
                throw new Exception("Invalid token!");

            var validation =
                tokenResult.Role == ECredentialRole.TECNICO.ToString() ||
                tokenResult.Role == ECredentialRole.CONSUMIDOR.ToString();

            if (validation is false)
                throw new Exception("Invalid credentials!");

            context.Items["Credentials"] = tokenResult;

            await next(context);
        }
    }
}