namespace HelpTechService.Location.Interfaces.ACL
{
    public interface ILocationContextFacade
    {
        Task<bool> ExistsDistrictById
            (int id);
    }
}