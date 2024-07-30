using HelpTechService.IAM.Domain.Model.ValueObjects.Consumer;

namespace HelpTechService.IAM.Domain.Model.Commands.Consumer
{
    public record RegisterConsumerCommand
        (int Id, int DistrictId, string ProfileUrl,
        string Firstname, string Lastname, int Age,
        string Genre, int Phone, string Email,
        EConsumerState ConsumerState);
}