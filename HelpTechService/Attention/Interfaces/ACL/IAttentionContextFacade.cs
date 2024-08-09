namespace HelpTechService.Attention.Interfaces.ACL
{
    public interface IAttentionContextFacade
    {
        Task<bool> ExistsJobById(int id);
    }
}