using HelpTechService.IAM.Interfaces.REST.Resources.Specialty;

namespace HelpTechService.IAM.Interfaces.REST.Transform.Specialty
{
    public class SpecialtyResourceFromEntityAssembler
    {
        public static SpecialtyResource ToResourceFromEntity
            (Domain.Model.Entities.Specialty entity) =>
            new(entity.Id, entity.Name);
    }
}