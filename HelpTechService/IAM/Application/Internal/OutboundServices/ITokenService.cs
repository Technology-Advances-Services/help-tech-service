namespace HelpTechService.IAM.Application.Internal.OutboundServices
{
    public interface ITokenService
    {
        string GenerateJwtToken(dynamic credential);

        dynamic? ValidateToken(string? token);
    }
}