using HelpTechService.Payment.Domain.Model.ValueObjects.QrTechnical;

namespace HelpTechService.Payment.Domain.Model.Commands.QrTechnical
{
    public record AddQrTechnicalCommand(string TechnicalId,
        string QrUrl, EQrTechnicalState QrTechnicalState);
}