using HelpTechService.Attention.Domain.Model.Commands.Job;
using HelpTechService.Attention.Interfaces.REST.Resources.Job;

namespace HelpTechService.Attention.Interfaces.REST.Transform.Job
{
    public class AssignJobDetailCommandFromResourceAssembler
    {
        public static AssignJobDetailCommand ToCommandFromResource
            (AssignJobDetailResource resource) =>
            new(resource.Id, resource.WorkDate, resource.Time,
                resource.LaborBudget, resource.MaterialBudget);
    }
}