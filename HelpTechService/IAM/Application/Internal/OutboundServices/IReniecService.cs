namespace HelpTechService.IAM.Application.Internal.OutboundServices
{
    public interface IReniecService
    {
        Task<bool> ValidateDni(string dni);
    }
}