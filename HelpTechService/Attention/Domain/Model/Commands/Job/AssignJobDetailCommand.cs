namespace HelpTechService.Attention.Domain.Model.Commands.Job
{
    public record AssignJobDetailCommand
        (int Id, DateTime WorkDate,
        decimal Time, double LaborBudget,
        double MaterialBudget);
}