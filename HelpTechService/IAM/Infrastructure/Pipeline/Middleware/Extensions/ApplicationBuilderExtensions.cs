using HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Components;

namespace HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRequestAuthorization
            (this IApplicationBuilder builder) =>
            builder.UseMiddleware
            <RequestAuthorizationMiddleware>();
    }
}