namespace HelpTechService.IAM.Interfaces.REST.Resources.User
{
    public record RecoveryPasswordResource
        (string Username, string Code, string Role);
}