using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HelpTechService.IAM.Infrastructure.Pipeline.Middleware.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute :
        Attribute, IAuthorizationFilter
    {
        private readonly string[] ListRoles;

        public AuthorizeAttribute
            (params string[] roles)
        {
            ListRoles = roles ?? Array.Empty<string>();
        }

        public void OnAuthorization
            (AuthorizationFilterContext context)
        {
            var allowAnonymous = context
                .ActionDescriptor
                .EndpointMetadata.OfType
                <AllowAnonymousAttribute>()
                .Any();

            if (allowAnonymous)
                return;

            var credential =
                context.HttpContext
                .Items["Credentials"]
                as dynamic;

            if (credential is null)
            {
                context.Result = new UnauthorizedResult();

                return;
            }

            if (ListRoles.Length > 0 && !HasRequiredRole(credential.Role))
            {
                context.Result = new ForbidResult();

                return;
            }
        }

        private bool HasRequiredRole
            (string role) => ListRoles
            .Contains(role);
    }
}