using HelpTechService.IAM.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Queries.Technical;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.Technical;

namespace HelpTechService.IAM.Application.Internal.QueryServices
{
    internal class TechnicalQueryService
        (ITechnicalRepository technicalRepository) :
        ITechnicalQueryService
    {
        public async Task<Technical?> Handle
            (GetTechnicalByIdQuery query) =>
            await technicalRepository
            .FindByIdAsync(int.Parse(query
                .Id.TrimStart('0')));
    }
}