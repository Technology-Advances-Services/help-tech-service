using HelpTechService.IAM.Application.Internal.OutboundServices;
using HelpTechService.IAM.Application.Internal.OutboundServices.ACL;
using HelpTechService.IAM.Domain.Model.Queries.TechnicalCredential;
using HelpTechService.IAM.Domain.Model.ValueObjects.Credential;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.TechnicalCredential;

namespace HelpTechService.IAM.Application.Internal.QueryServices
{
    internal class TechnicalCredentialQueryService
        (ITechnicalCredentialRepository technicalCredentialRepository,
        IEncryptionService encryptionService,
        ITokenService tokenService,
        ExternalSubscriptionService externalSubscriptionService) :
        ITechnicalCredentialQueryService
    {
        public async Task<dynamic?> Handle
            (GetTechnicalCredentialByTechnicalIdAndCodeQuery query)
        {
            var result = await technicalCredentialRepository
                .FindByTechnicalIdAsync(query.TechnicalId);

            if (string.IsNullOrEmpty(result) ||
                await externalSubscriptionService
                .CurrentContractByTechnicalId
                (query.TechnicalId) is false)
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
                    Id = query.TechnicalId.ToString(),
                    query.Code,
                    Role = ECredentialRole
                    .TECNICO.ToString()
                }),
                Result = true
            };
        }
    }
}