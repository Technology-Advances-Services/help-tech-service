using HelpTechService.Report.Domain.Model.Commands.Complaint;
using HelpTechService.Report.Domain.Model.ValueObjects.Complaint;
using HelpTechService.Report.Interfaces.REST.Resources.Complaint;

namespace HelpTechService.Report.Interfaces.REST.Transform.Complaint
{
    public class RegisterComplaintCommandFromResourceAssembler
    {
        public static RegisterComplaintCommand ToCommandFromResource
            (RegisterComplaintResource resource) =>
            new(resource.TypeComplaintId, resource.JobId,
                Enum.Parse<EComplaintSender>(resource.Sender),
                resource.Description, EComplaintState.ENTREGADO);
    }
}