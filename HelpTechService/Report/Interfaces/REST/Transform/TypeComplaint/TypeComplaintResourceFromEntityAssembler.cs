using HelpTechService.Report.Interfaces.REST.Resources.TypeComplaint;

namespace HelpTechService.Report.Interfaces.REST.Transform.TypeComplaint
{
    public class TypeComplaintResourceFromEntityAssembler
    {
        public static TypeComplaintResource ToResourceFromEntity
            (Domain.Model.Entities.TypeComplaint entity) =>
            new(entity.Id, entity.Name);
    }
}