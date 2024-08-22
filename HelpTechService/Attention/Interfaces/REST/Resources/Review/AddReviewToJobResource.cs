namespace HelpTechService.Attention.Interfaces.REST.Resources.Review
{
    public record AddReviewToJobResource
        (string TechnicalId, string ConsumerId,
        int Score, string Opinion);
}