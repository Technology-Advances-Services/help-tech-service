﻿namespace HelpTechService.Attention.Interfaces.REST.Resources.Job
{
    public record JobResource
        (int Id, int AgendaId, string ConsumerId,
        DateTime? AnswerDate, DateTime? WorkDate,
        string Address, string Description,
        decimal? Time, decimal? LaborBudget,
        decimal? MaterialBudget, decimal? AmountFinal,
        string JobState);
}