namespace HelpTechService.Subscription.Interfaces.ACL
{
    public interface ISubscriptionContextFacade
    {
        Task<bool> CurrentContractByTechnicalId
            (string technicalId);

        Task<bool> CurrentContractByConsumerId
            (string consumerId);
    }
}