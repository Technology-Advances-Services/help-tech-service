namespace HelpTechService.IAM.Domain.Model.Queries.ConsumerCredential
{
    public record GetConsumerCredentialByConsumerIdAndCodeQuery
        (string ConsumerId, string Code);
}