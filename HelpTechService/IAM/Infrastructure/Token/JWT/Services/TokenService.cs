using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HelpTechService.IAM.Application.Internal.OutboundServices;
using HelpTechService.IAM.Infrastructure.Token.JWT.Configuration;

namespace HelpTechService.IAM.Infrastructure.Token.JWT.Services
{
    internal class TokenService
        (IOptions<JwtSettings> tokenSettings) :
        ITokenService
    {
        private readonly JwtSettings TokenConfiguration = tokenSettings.Value;

        public string GenerateJwtToken(dynamic credential)
        {
            SymmetricSecurityKey securityKey = new
                (Encoding.ASCII.GetBytes
                (TokenConfiguration.SecretKey));

            SigningCredentials credentials = new
                (securityKey, SecurityAlgorithms.HmacSha256);

            Claim[]? claims =
                [
                    new Claim(ClaimTypes.Sid, credential.Id),
                    new Claim(ClaimTypes.Hash, credential.Code),
                    new Claim(ClaimTypes.Role, credential.Role)
                ];

            JwtSecurityToken token = new(
                issuer: TokenConfiguration.Issuer,
                audience: TokenConfiguration.Audience,
                claims: claims,
                expires: DateTime.UtcNow
                .AddMinutes(TokenConfiguration.Expire),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public dynamic? ValidateToken(string? token)
        {
            if (string.IsNullOrEmpty(token))
                return null;

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

                var principal = tokenHandler.ValidateToken(token,
                    validationParameters, out SecurityToken securityToken);

                if (securityToken is JwtSecurityToken jwtToken)
                    if (!jwtToken.Header.Alg.Equals(SecurityAlgorithms
                        .HmacSha256, StringComparison
                        .InvariantCultureIgnoreCase))
                        return null;

                var result = (JwtSecurityToken)securityToken;

                var id = Convert.ToInt32(result.Claims.First
                    (claim => claim.Type == ClaimTypes.Sid).Value);

                var code = Convert.ToString(result.Claims.First
                    (claim => claim.Type == ClaimTypes.Hash).Value);

                var role = Convert.ToString(result.Claims.First
                    (claim => claim.Type == ClaimTypes.Role).Value);

                return new { Id = id, Code = code, Role = role };
            }
            catch (Exception) { return null; }
        }

        private bool LifetimeValidator(DateTime? notBefore,
            DateTime? expires, SecurityToken securityToken,
            TokenValidationParameters validationParameters)
        {
            if (expires != null)
                if (DateTime.UtcNow < expires) return true;

            return false;
        }
    }
}