using HelpTechService.Payment.Domain.Model.Commands.QrTechnical;
using HelpTechService.Payment.Domain.Repositories;
using HelpTechService.Payment.Domain.Services.QrTechnical;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Payment.Application.Internal.CommandServices
{
    internal class QrTechnicalCommandService
        (IQrTechnicalRepository qrTechnicalRepository,
        IUnitOfWork unitOfWork) :
        IQrTechnicalCommandService
    {
        public async Task<bool> Handle
            (AddQrTechnicalCommand command)
        {
            try
            {
                await qrTechnicalRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}