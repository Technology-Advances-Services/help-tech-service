using HelpTechService.IAM.Interfaces.REST.Resources.Technical;

namespace HelpTechService.IAM.Interfaces.REST.Transform.Technical
{
    public class TechnicalResourceFromEntityAssembler
    {
        public static TechnicalResource ToResourceFromEntity
            (Domain.Model.Aggregates.Technical entity) =>
            new(entity.Id, entity.SpecialtiesId, entity.DistrictsId,
                entity.ProfileUrl, entity.Firstname, entity.Lastname,
                entity.Age, entity.Genre, entity.Phone, entity.Email,
                entity.Availability);
    }
}