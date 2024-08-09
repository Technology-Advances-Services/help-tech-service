using HelpTechService.Attention.Domain.Model.Queries.Job;
using HelpTechService.Attention.Domain.Services.Job;

namespace HelpTechService.Attention.Interfaces.ACL.Services
{
    internal class AttentionContextFacade
        (IJobQueryService jobQueryService) :
        IAttentionContextFacade
    {
        public async Task<bool> ExistsAttentionById(int id) =>
            await jobQueryService.Handle
            (new GetJobByIdQuery(id)) != null;
    }
}