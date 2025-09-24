using HelpTechService.Payment.Domain.Model.Commands.QrTechnical;
using HelpTechService.Payment.Domain.Model.ValueObjects.QrTechnical;
using HelpTechService.Payment.Interfaces.REST.Resources.QrTechnical;

namespace HelpTechService.Payment.Interfaces.REST.Transform.QrTechnical
{
    public class AddQrTechnicalCommandFromResourceAssembler
    {
        public static AddQrTechnicalCommand ToCommandFromResource
            (AddQrTechnicalResource resource) =>
            new(resource.TechnicalId, resource.QrUrl,
                EQrTechnicalState.ACTIVO);
    }
}