﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using HelpTechService.IAM.Infrastructure.Token.JWT.Configuration;

namespace HelpTechService.IAM.Infrastructure.Token.JWT.Services
{
    internal class TokenValidationHandler
        (IOptions<JwtSettings> tokenSettings):
        DelegatingHandler
    {
        private readonly JwtSettings TokenConfiguration = tokenSettings.Value;

        private static bool TryRetrieveToken
            (HttpRequestMessage request, out string token)
        {
            token = string.Empty;

            if (!request.Headers.TryGetValues
                ("Authorization", out IEnumerable<string>? authzHeaders) ||
                authzHeaders.Count() > 1)
                return false;

            var bearerToken = authzHeaders.ElementAt(0);

            token = bearerToken.StartsWith("Bearer ") ?
                bearerToken.Substring(7) : bearerToken;

            return true;
        }

        protected override Task<HttpResponseMessage> SendAsync
            (HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;

            if (!TryRetrieveToken(request, out string token))
            {
                statusCode = HttpStatusCode.Unauthorized;

                return base.SendAsync(request, cancellationToken);
            }

            try
            {
                var securityKey = new SymmetricSecurityKey
                    (Encoding.Default.GetBytes
                    (TokenConfiguration.SecretKey));

                JwtSecurityTokenHandler tokenHandler = new();

                TokenValidationParameters validationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = TokenConfiguration.Issuer,
                    ValidAudience = TokenConfiguration.Audience,
                    IssuerSigningKey = securityKey,
                    LifetimeValidator = LifetimeValidator,
                    ClockSkew = TimeSpan.Zero
                };

                Thread.CurrentPrincipal = tokenHandler.ValidateToken
                    (token, validationParameters, out SecurityToken securityToken);

                if (securityToken is JwtSecurityToken jwtToken)
                    if (!jwtToken.Header.Alg.Equals(SecurityAlgorithms
                        .HmacSha256, StringComparison
                        .InvariantCultureIgnoreCase))
                        statusCode = HttpStatusCode.Unauthorized;

                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException)
            { statusCode = HttpStatusCode.Unauthorized; }
            catch (Exception)
            { statusCode = HttpStatusCode.InternalServerError; }

            return Task<HttpResponseMessage>.Factory.StartNew
                (() => new HttpResponseMessage(statusCode) { });
        }

        private bool LifetimeValidator
            (DateTime? notBefore, DateTime? expires,
            SecurityToken securityToken,
            TokenValidationParameters validationParameters)
        {
            if (expires != null)
                if (DateTime.UtcNow < expires) return true;

            return false;
        }
    }
}