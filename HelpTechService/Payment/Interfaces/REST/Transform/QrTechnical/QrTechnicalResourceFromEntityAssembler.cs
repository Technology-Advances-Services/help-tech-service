using HelpTechService.Payment.Interfaces.REST.Resources.QrTechnical;

namespace HelpTechService.Payment.Interfaces.REST.Transform.QrTechnical
{
    public class QrTechnicalResourceFromEntityAssembler
    {
        public static QrTechnicalResource ToResourceFromEntity
            (Domain.Model.Aggregates.QrTechnical entity) =>
            new(entity.Id, entity.TechnicalsId.ToString().Length == 8 ?
                entity.TechnicalsId.ToString() :
                "0" + entity.TechnicalsId.ToString(),
                entity.RegistrationDate, entity.QrUrl, entity.State);
    }
}