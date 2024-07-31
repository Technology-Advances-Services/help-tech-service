using HelpTechService.IAM.Domain.Model.Queries.ConsumerCredential;

namespace HelpTechService.IAM.Domain.Services.ConsumerCredential
{
    public interface IConsumerCredentialQueryService
    {
        Task<string?> Handle
            (GetConsumerCredentialByConsumerIdAndCodeQuery query);
    }
}