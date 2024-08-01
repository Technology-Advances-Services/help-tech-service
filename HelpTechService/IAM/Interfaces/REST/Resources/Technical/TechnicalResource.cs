﻿namespace HelpTechService.IAM.Interfaces.REST.Resources.Technical
{
    public record TechnicalResource
        (int Id, int SpecialtyId, int DistrictId,
        string ProfileUrl, string Firstname,
        string Lastname, int Age, string Genre,
        int Phone, string Email, string Availability);
}