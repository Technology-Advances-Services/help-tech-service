using HelpTechService.IAM.Interfaces.REST.Resources.Consumer;

namespace HelpTechService.IAM.Interfaces.REST.Transform.Consumer
{
    public class ConsumerResourceFromEntityAssembler
    {
        public static ConsumerResource ToResourceFromEntity
            (Domain.Model.Aggregates.Consumer entity) =>
            new(entity.Id.ToString().Length == 8 ?
                entity.Id.ToString() : "0" +
                entity.Id.ToString(),
                entity.DistrictsId, entity.ProfileUrl,
                entity.Firstname, entity.Lastname, entity.Age,
                entity.Genre, entity.Phone, entity.Email);
    }
}