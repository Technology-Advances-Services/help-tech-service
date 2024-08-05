using HelpTechService.Report.Domain.Model.Entities;
using HelpTechService.Report.Domain.Model.Queries.TypeComplaint;
using HelpTechService.Report.Domain.Repositories;
using HelpTechService.Report.Domain.Services.TypeComplaint;

namespace HelpTechService.Report.Application.Internal.QueryServices
{
    internal class TypeComplaintQueryService
        (ITypeComplaintRepository typeComplaintRepository) :
        ITypeComplaintQueryService
    {
        public async Task<IEnumerable<TypeComplaint>> Handle
            (GetAllTypesComplaintsQuery query) =>
            await typeComplaintRepository.ListAsync();

        public async Task<TypeComplaint?> Handle
            (GetTypeComplaintByIdQuery query) =>
            await typeComplaintRepository
            .FindByIdAsync(query.Id);
    }
}