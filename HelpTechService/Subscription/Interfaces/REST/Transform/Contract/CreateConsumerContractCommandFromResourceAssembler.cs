using HelpTechService.Subscription.Domain.Model.Commands.Contract;
using HelpTechService.Subscription.Domain.Model.ValueObjects.Contract;
using HelpTechService.Subscription.Interfaces.REST.Resources.Contract;

namespace HelpTechService.Subscription.Interfaces.REST.Transform.Contract
{
    public class CreateConsumerContractCommandFromResourceAssembler
    {
        public static CreateContractCommand ToCommandFromResource
            (CreateConsumerContractResource resource) =>
            new(resource.MembershipId, null, resource.ConsumerId,
                resource.Name, resource.Price, resource.Policies,
                EContractState.VIGENTE);
    }
}