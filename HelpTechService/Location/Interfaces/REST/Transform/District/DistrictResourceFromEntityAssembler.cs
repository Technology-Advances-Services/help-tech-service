using HelpTechService.Location.Interfaces.REST.Resources.District;

namespace HelpTechService.Location.Interfaces.REST.Transform.District
{
    public class DistrictResourceFromEntityAssembler
    {
        public static DistrictResource ToResourceFromEntity
            (Domain.Model.Aggregates.District entity) =>
            new(entity.Id, entity.DepartmentsId, entity.Name);
    }
}