namespace HelpTechService.IAM.Interfaces.REST.Resources.User
{
    public record UserResource
        (string Username, string Password,
        string Role);
}