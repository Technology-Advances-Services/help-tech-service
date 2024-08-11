namespace HelpTechService.Attention.Domain.Model.Commands.Job
{
    public record AssignJobDetailCommand
        (int Id, DateTime WorkDate,
        decimal Time, decimal LaborBudget,
        decimal MaterialBudget);
}