namespace HelpTechService.IAM.Interfaces.ACL
{
    public interface IIamContextFacade
    {
        Task<bool> ExistsTechnicalById
            (string id);

        Task<bool> ExistsConsumerById
            (string id);
    }
}