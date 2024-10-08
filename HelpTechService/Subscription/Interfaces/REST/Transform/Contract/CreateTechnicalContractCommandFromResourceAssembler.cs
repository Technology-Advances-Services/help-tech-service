﻿using HelpTechService.Subscription.Domain.Model.Commands.Contract;
using HelpTechService.Subscription.Domain.Model.ValueObjects.Contract;
using HelpTechService.Subscription.Interfaces.REST.Resources.Contract;

namespace HelpTechService.Subscription.Interfaces.REST.Transform.Contract
{
    public class CreateTechnicalContractCommandFromResourceAssembler
    {
        public static CreateContractCommand ToCommandFromResource
            (CreateTechnicalContractResource resource) =>
            new(resource.MembershipId, resource.TechnicalId,
                null, resource.Name, resource.Price, resource.Policies,
                EContractState.VIGENTE);
    }
}