namespace HelpTechService.IAM.Interfaces.REST.Resources.User
{
    public record UpdateCredentialResource
        (string Username, string Code, string Role);
}