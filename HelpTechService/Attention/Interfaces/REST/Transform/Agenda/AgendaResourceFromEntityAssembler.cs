using HelpTechService.Attention.Interfaces.REST.Resources.Agenda;

namespace HelpTechService.Attention.Interfaces.REST.Transform.Agenda
{
    public class AgendaResourceFromEntityAssembler
    {
        public static AgendaResource ToResourceFromEntity
            (Domain.Model.Entities.Agenda entity) =>
            new(entity.Id, entity.TechnicalsId
                .ToString().Length == 8 ?
                entity.TechnicalsId.ToString() : "0" +
                entity.TechnicalsId.ToString(),
                entity.RegistrationDate);
    }
}