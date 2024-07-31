using HelpTechService.IAM.Domain.Model.Queries.Specialty;

namespace HelpTechService.IAM.Domain.Services.Specialty
{
    public interface ISpecialtyQueryService
    {
        Task<IEnumerable<Model.Entities.Specialty>> Handle
            (GetAllSpecialtiesQuery query);

        Task<Model.Entities.Specialty?> Handle
            (GetSpecialtyByIdQuery query);
    }
}