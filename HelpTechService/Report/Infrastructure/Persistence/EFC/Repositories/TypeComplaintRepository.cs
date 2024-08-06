using HelpTechService.Report.Domain.Model.Entities;
using HelpTechService.Report.Domain.Repositories;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Configuration;
using HelpTechService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace HelpTechService.Report.Infrastructure.Persistence.EFC.Repositories
{
    internal class TypeComplaintRepository
        (HelpTechContext context) :
        BaseRepository<TypeComplaint>(context),
        ITypeComplaintRepository
    { }
}