using HelpTechService.IAM.Domain.Model.Queries.TechnicalCredential;

namespace HelpTechService.IAM.Domain.Services.TechnicalCredential
{
    public interface ITechnicalCredentialQueryService
    {
        Task<dynamic?> Handle
            (GetTechnicalCredentialByTechnicalIdAndCodeQuery query);
    }
}