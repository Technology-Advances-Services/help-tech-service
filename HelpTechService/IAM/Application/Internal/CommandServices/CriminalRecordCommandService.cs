using HelpTechService.IAM.Domain.Model.Commands.CriminalRecord;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.CriminalRecord;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.IAM.Application.Internal.CommandServices
{
    internal class CriminalRecordCommandService
        (ICriminalRecordRepository criminalRecordRepository,
        IUnitOfWork unitOfWork) :
        ICriminalRecordCommandService
    {
        public async Task<bool> Handle
            (AddCriminalRecordToTechnicalCommand command)
        {
            try
            {
                await criminalRecordRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}