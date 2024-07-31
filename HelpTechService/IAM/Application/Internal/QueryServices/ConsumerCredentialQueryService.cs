using HelpTechService.IAM.Domain.Model.Queries.ConsumerCredential;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.ConsumerCredential;

namespace HelpTechService.IAM.Application.Internal.QueryServices
{
    internal class ConsumerCredentialQueryService
        (IConsumerCredentialRepository consumerCredentialRepository) :
        IConsumerCredentialQueryService
    {
        public async Task<dynamic?> Handle
            (GetConsumerCredentialByConsumerIdAndCodeQuery query)
        {
            throw new NotImplementedException();
        }
    }
}