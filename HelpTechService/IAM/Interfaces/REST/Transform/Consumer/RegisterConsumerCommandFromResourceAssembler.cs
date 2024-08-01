using HelpTechService.IAM.Domain.Model.Commands.Consumer;
using HelpTechService.IAM.Domain.Model.ValueObjects.Consumer;
using HelpTechService.IAM.Interfaces.REST.Resources.Consumer;

namespace HelpTechService.IAM.Interfaces.REST.Transform.Consumer
{
    public class RegisterConsumerCommandFromResourceAssembler
    {
        public static RegisterConsumerCommand ToCommandFromResource
            (RegisterConsumerResource resource) =>
            new(resource.Id, resource.DistrictId, resource.ProfileUrl,
                resource.Firstname, resource.Lastname, resource.Age,
                resource.Genre, resource.Phone, resource.Email,
                EConsumerState.ACTIVO);
    }
}