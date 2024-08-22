using HelpTechService.IAM.Domain.Model.Queries.Consumer;
using HelpTechService.IAM.Domain.Model.Queries.Technical;
using HelpTechService.IAM.Domain.Services.Consumer;
using HelpTechService.IAM.Domain.Services.Technical;

namespace HelpTechService.IAM.Interfaces.ACL.Services
{
    internal class IamContextFacade
        (ITechnicalQueryService technicalQueryService,
        IConsumerQueryService consumerQueryService) :
        IIamContextFacade
    {
        public async Task<bool> ExistsTechnicalById
            (string id) =>
            await technicalQueryService.Handle
            (new GetTechnicalByIdQuery(id)) != null;

        public async Task<bool> ExistsConsumerById
            (string id) =>
            await consumerQueryService.Handle
            (new GetConsumerByIdQuery(id)) != null;
    }
}