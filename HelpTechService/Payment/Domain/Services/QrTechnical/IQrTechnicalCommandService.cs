using HelpTechService.Payment.Domain.Model.Commands.QrTechnical;

namespace HelpTechService.Payment.Domain.Services.QrTechnical
{
    public interface IQrTechnicalCommandService
    {
        Task<bool> Handle(AddQrTechnicalCommand command);
    }
}