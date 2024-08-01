namespace HelpTechService.IAM.Interfaces.ACL
{
    public interface IIamContextFacade
    {
        Task<bool> ExistsTechnicalById
            (int id);

        Task<bool> ExistsConsumerById
            (int id);
    }
}