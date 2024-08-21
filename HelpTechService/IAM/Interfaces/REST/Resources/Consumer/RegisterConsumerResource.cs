namespace HelpTechService.IAM.Interfaces.REST.Resources.Consumer
{
    public record RegisterConsumerResource
        (string Id, int DistrictId, string ProfileUrl,
        string Firstname, string Lastname, int Age,
        string Genre, int Phone, string Email,
        string Code);
}