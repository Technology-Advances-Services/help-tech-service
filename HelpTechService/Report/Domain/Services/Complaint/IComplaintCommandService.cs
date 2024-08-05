using HelpTechService.Report.Domain.Model.Commands.Complaint;

namespace HelpTechService.Report.Domain.Services.Complaint
{
    public interface IComplaintCommandService
    {
        Task<bool> Handle
            (RegisterComplaintCommand command);
    }
}