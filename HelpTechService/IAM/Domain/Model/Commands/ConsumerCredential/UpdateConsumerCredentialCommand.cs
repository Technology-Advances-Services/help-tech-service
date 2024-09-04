namespace HelpTechService.IAM.Domain.Model.Commands.ConsumerCredential
{
    public record UpdateConsumerCredentialCommand
        (string ConsumerId, string Code);
}