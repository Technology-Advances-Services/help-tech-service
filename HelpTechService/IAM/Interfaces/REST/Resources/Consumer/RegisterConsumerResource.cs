namespace HelpTechService.IAM.Interfaces.REST.Resources.Consumer
{
    public record RegisterConsumerResource
        (int Id, int DistrictId, string ProfileUrl,
        string Firstname, string Lastname, int Age,
        string Genre, int Phone, string Email,
        string Code);
}