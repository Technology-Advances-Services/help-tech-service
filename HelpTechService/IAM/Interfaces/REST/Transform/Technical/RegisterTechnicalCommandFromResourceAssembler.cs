using HelpTechService.IAM.Domain.Model.Commands.Technical;
using HelpTechService.IAM.Domain.Model.ValueObjects.Technical;
using HelpTechService.IAM.Interfaces.REST.Resources.Technical;

namespace HelpTechService.IAM.Interfaces.REST.Transform.Technical
{
    public class RegisterTechnicalCommandFromResourceAssembler
    {
        public static RegisterTechnicalCommand ToCommandFromResource
            (RegisterTechnicalResource resource) =>
            new(resource.Id, resource.SpecialtyId,
                resource.DistrictId, resource.ProfileUrl, resource.Firstname,
                resource.Lastname, resource.Age, resource.Genre, resource.Phone,
                resource.Email, ETechnicalAvailability.DISPONIBLE, ETechnicalState.ACTIVO);
    }
}