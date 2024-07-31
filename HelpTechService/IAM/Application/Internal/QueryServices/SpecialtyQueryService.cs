using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.IAM.Domain.Model.Queries.Specialty;
using HelpTechService.IAM.Domain.Repositories;
using HelpTechService.IAM.Domain.Services.Specialty;

namespace HelpTechService.IAM.Application.Internal.QueryServices
{
    internal class SpecialtyQueryService
        (ISpecialtyRepository specialtyRepository) :
        ISpecialtyQueryService
    {
        public async Task<IEnumerable<Specialty>> Handle
            (GetAllSpecialtiesQuery query) =>
            await specialtyRepository.ListAsync();

        public async Task<Specialty?> Handle
            (GetSpecialtyByIdQuery query) =>
            await specialtyRepository
            .FindByIdAsync(query.Id);
    }
}