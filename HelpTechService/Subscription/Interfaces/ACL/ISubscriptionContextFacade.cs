namespace HelpTechService.Subscription.Interfaces.ACL
{
    public interface ISubscriptionContextFacade
    {
        Task<bool> CurrentContractByTechnicalId
            (int technicalId);

        Task<bool> CurrentContractByConsumerId
            (int consumerId);
    }
}