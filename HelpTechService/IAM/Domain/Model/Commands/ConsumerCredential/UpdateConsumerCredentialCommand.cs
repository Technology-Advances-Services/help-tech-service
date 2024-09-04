namespace HelpTechService.IAM.Domain.Model.Commands.ConsumerCredential
{
    public record UpdateConsumerCredentialCommand
        (int ConsumerId, string Code);
}