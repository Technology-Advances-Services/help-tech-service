namespace HelpTechService.Attention.Interfaces.REST.Resources.Job
{
    public record AssignJobDetailResource
        (int Id, DateTime WorkDate,
        decimal Time, decimal LaborBudget,
        decimal MaterialBudget);
}