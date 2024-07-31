using HelpTechService.IAM.Domain.Model.Queries.TechnicalCredential;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.TechnicalCredential;

namespace HelpTechService.IAM.Application.Internal.QueryServices
{
    internal class TechnicalCredentialQueryService
        (ITechnicalCredentialRepository technicalCredentialRepository) :
        ITechnicalCredentialQueryService
    {
        public async Task<dynamic?> Handle
            (GetTechnicalCredentialByTechnicalIdAndCodeQuery query)
        {
            throw new NotImplementedException();
        }
    }
}