namespace HelpTechService.Attention.Interfaces.REST.Resources.Review
{
    public record ReviewResource
        (string TechnicalId, string ConsumerId,
        int Score, string Opinion,
        string ReviewState);
}