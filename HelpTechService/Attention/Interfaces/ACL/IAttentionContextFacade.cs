namespace HelpTechService.Attention.Interfaces.ACL
{
    public interface IAttentionContextFacade
    {
        Task<bool> ExistsAttentionById(int id);
    }
}