namespace HelpTechService.Attention.Interfaces.REST.Resources.Review
{
    public record AddReviewToJobResource
        (int TechnicalId, int ConsumerId,
        int Score, string Opinion,
        string ReviewState);
}