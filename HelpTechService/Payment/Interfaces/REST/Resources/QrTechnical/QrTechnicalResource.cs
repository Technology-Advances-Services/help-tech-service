namespace HelpTechService.Payment.Interfaces.REST.Resources.QrTechnical
{
    public record QrTechnicalResource(int Id, string TechnicalId,
        DateTime RegistrationDate, string QrUrl, string State);
}