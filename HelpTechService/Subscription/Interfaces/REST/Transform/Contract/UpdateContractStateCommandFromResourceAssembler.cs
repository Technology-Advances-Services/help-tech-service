using HelpTechService.Subscription.Domain.Model.Commands.Contract;
using HelpTechService.Subscription.Domain.Model.ValueObjects.Contract;
using HelpTechService.Subscription.Interfaces.REST.Resources.Contract;

namespace HelpTechService.Subscription.Interfaces.REST.Transform.Contract
{
    public class UpdateContractStateCommandFromResourceAssembler
    {
        public static UpdateContractStateCommand ToCommandFromResource
            (UpdateContractStateResource resource) =>
            new(resource.Id, Enum.Parse<EContractState>
                (resource.ContractState));
    }
}