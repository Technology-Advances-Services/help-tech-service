namespace HelpTechService.IAM.Domain.Model.Commands.ConsumerCredential
{
    public record AddConsumerCredentialCommand
        (string ConsumerId, string Code);
}