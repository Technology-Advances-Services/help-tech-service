using HelpTechService.IAM.Domain.Model.Queries.Technical;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.Technical;

namespace HelpTechService.IAM.Application.Internal.QueryServices
{
    internal class TechnicalQueryService
        (ITechnicalRepository technicalRepository) :
        ITechnicalQueryService
    {
        public async Task<bool> Handle
            (GetTechnicalByIdQuery query) =>
            await technicalRepository
            .FindByIdAsync(query.Id) !=
            null;
    }
}