using HelpTechService.Attention.Domain.Model.Commands.Job;
using HelpTechService.Attention.Domain.Model.ValueObjects.Job;
using HelpTechService.Attention.Interfaces.REST.Resources.Job;

namespace HelpTechService.Attention.Interfaces.REST.Transform.Job
{
    public class RegisterRequestJobCommandFromResourceAssembler
    {
        public static RegisterRequestJobCommand ToCommandFromResource
            (RegisterRequestJobResource resource) =>
            new(resource.AgendaId, resource.ConsumerId,
                resource.Address, resource.Description,
                EJobState.ENPROCESO);
    }
}