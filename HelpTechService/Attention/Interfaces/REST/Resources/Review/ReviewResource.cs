namespace HelpTechService.Attention.Interfaces.REST.Resources.Review
{
    public record ReviewResource
        (int TechnicalId, int ConsumerId,
        int Score, string Opinion,
        string ReviewState);
}