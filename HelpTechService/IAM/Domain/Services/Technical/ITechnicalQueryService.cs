using HelpTechService.IAM.Domain.Model.Queries.Technical;

namespace HelpTechService.IAM.Domain.Services.Technical
{
    public interface ITechnicalQueryService
    {
        Task<bool> Handle
            (GetTechnicalByIdQuery query);
    }
}