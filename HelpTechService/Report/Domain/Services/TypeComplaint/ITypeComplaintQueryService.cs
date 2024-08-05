using HelpTechService.Report.Domain.Model.Queries.TypeComplaint;

namespace HelpTechService.Report.Domain.Services.TypeComplaint
{
    public interface ITypeComplaintQueryService
    {
        Task<IEnumerable<Model.Entities.TypeComplaint>> Handle
            (GetAllTypesComplaintsQuery query);

        Task<Model.Entities.TypeComplaint?> Handle
            (GetTypeComplaintByIdQuery query);
    }
}