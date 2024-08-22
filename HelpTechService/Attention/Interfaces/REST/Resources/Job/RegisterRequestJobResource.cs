namespace HelpTechService.Attention.Interfaces.REST.Resources.Job
{
    public record RegisterRequestJobResource
        (int AgendaId, string ConsumerId,
        string Address, string Description);
}