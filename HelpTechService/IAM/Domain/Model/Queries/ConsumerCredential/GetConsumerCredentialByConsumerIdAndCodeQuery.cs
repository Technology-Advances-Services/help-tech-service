namespace HelpTechService.IAM.Domain.Model.Queries.ConsumerCredential
{
    public record GetConsumerCredentialByConsumerIdAndCodeQuery
        (int ConsumerId, string Code);
}