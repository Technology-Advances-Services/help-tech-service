namespace HelpTechService.Attention.Interfaces.REST.Resources.Job
{
    public record RegisterRequestJobResource
        (int AgendaId, int ConsumerId,
        string Address, string Description);
}