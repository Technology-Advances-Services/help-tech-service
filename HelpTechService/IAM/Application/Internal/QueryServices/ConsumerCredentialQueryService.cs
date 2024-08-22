using HelpTechService.IAM.Application.Internal.OutboundServices;
using HelpTechService.IAM.Application.Internal.OutboundServices.ACL;
using HelpTechService.IAM.Domain.Model.Queries.ConsumerCredential;
using HelpTechService.IAM.Domain.Model.ValueObjects.Credential;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.ConsumerCredential;

namespace HelpTechService.IAM.Application.Internal.QueryServices
{
    internal class ConsumerCredentialQueryService
        (IConsumerCredentialRepository consumerCredentialRepository,
        IEncryptionService encryptionService,
        ITokenService tokenService,
        ExternalSubscriptionService externalSubscriptionService) :
        IConsumerCredentialQueryService
    {
        public async Task<dynamic?> Handle
            (GetConsumerCredentialByConsumerIdAndCodeQuery query)
        {
            if (query.ConsumerId.Length < 8 ||
                query.ConsumerId.Length > 8)
                return null;

            var result = await consumerCredentialRepository
                .FindByConsumerIdAsync(int.Parse(query
                .ConsumerId.TrimStart('0')));

            if (string.IsNullOrEmpty(result) ||
                await externalSubscriptionService
                .CurrentContractByConsumerId
                (query.ConsumerId) is false)
                return null;

            if (!encryptionService.VerifyHash
                (query.Code, result[..24],
                result[24..]))
                return null;

            return new
            {
                Token = tokenService.GenerateJwtToken
                (new
                {
                    Id = query.ConsumerId.ToString(),
                    query.Code,
                    Role = ECredentialRole
                    .CONSUMIDOR.ToString()
                }),
                Result = true
            };
        }
    }
}