using HelpTechService.IAM.Domain.Model.ValueObjects.Technical;

namespace HelpTechService.IAM.Domain.Model.Commands.Technical
{
    public record RegisterTechnicalCommand
        (string Id, int SpecialtyId, int DistrictId,
        string ProfileUrl, string Firstname,
        string Lastname, int Age, string Genre,
        int Phone, string Email,
        ETechnicalAvailability TechnicalAvailability,
        ETechnicalState TechnicalState);
}