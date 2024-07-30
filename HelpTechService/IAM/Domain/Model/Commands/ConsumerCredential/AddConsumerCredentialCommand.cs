namespace HelpTechService.IAM.Domain.Model.Commands.ConsumerCredential
{
    public record AddConsumerCredentialCommand
        (int ConsumerId, string Code);
}