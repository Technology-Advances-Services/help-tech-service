namespace HelpTechService.Attention.Interfaces.REST.Resources.Job
{
    public record JobResource
        (int Id, int AgendaId, int ConsumerId,
        DateTime? AnswerDate, DateTime? WorkDate,
        string Address, string Description,
        decimal? Time, double? LaborBudget,
        double? MaterialBudget, string JobState);
}