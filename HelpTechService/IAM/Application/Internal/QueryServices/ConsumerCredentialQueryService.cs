using HelpTechService.IAM.Application.Internal.OutboundServices;
using HelpTechService.IAM.Domain.Model.Queries.ConsumerCredential;
using HelpTechService.IAM.Domain.Model.ValueObjects.Credential;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.ConsumerCredential;

namespace HelpTechService.IAM.Application.Internal.QueryServices
{
    internal class ConsumerCredentialQueryService
        (IConsumerCredentialRepository consumerCredentialRepository,
        IEncryptionService encryptionService,
        ITokenService tokenService) :
        IConsumerCredentialQueryService
    {
        public async Task<dynamic?> Handle
            (GetConsumerCredentialByConsumerIdAndCodeQuery query)
        {
            var result = await consumerCredentialRepository
                .FindByConsumerIdAsync(query.ConsumerId);

            if (string.IsNullOrEmpty(result))
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