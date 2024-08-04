using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.IAM.Domain.Model.Commands.Technical;
using HelpTechService.IAM.Domain.Model.ValueObjects.Technical;
using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.Location.Domain.Model.Aggregates;
using HelpTechService.Subscription.Domain.Model.Aggregates;

namespace HelpTechService.IAM.Domain.Model.Aggregates
{
    public class Technical
    {
        public int Id { get; private set; }
        public int SpecialtiesId { get; private set; }
        public int DistrictsId { get; private set; }
        public string ProfileUrl { get; private set; } = null!;
        public string Firstname { get; private set; } = null!;
        public string Lastname { get; private set; } = null!;
        public int Age { get; private set; }
        public string Genre { get; private set; } = null!;
        public int Phone { get; private set; }
        public string Email { get; private set; } = null!;
        public string Availability { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual District District { get; } = null!;
        public virtual Specialty Specialty { get; } = null!;
        public virtual TechnicalCredential? TechnicalCredential { get; }

        public virtual ICollection<Agenda> Agendas { get; } = [];
        public virtual ICollection<Contract> Contracts { get; } = [];
        public virtual ICollection<Chat> Chats { get; } = [];
        public virtual ICollection<CriminalRecord> CriminalsRecords { get; } = [];
        public virtual ICollection<Review> Reviews { get; } = [];

        public Technical()
        {
            this.Id = 0;
            this.SpecialtiesId = 0;
            this.DistrictsId = 0;
            this.ProfileUrl = string.Empty;
            this.Firstname = string.Empty;
            this.Lastname = string.Empty;
            this.Age = 0;
            this.Genre = string.Empty;
            this.Phone = 0;
            this.Email = string.Empty;
            this.Availability = string.Empty;
            this.State = string.Empty;
        }
        public Technical
            (int id, int specialtyId, int districtId,
            string profileUrl, string firstname,
            string lastname, int age, string genre,
            int phone, string email,
            ETechnicalAvailability technicalAvailability,
            ETechnicalState technicalState)
        {
            this.Id = id;
            this.SpecialtiesId = specialtyId;
            this.DistrictsId = districtId;
            this.ProfileUrl = profileUrl;
            this.Firstname = firstname.ToUpper();
            this.Lastname = lastname.ToUpper();
            this.Age = age;
            this.Genre = genre;
            this.Phone = phone;
            this.Email = email;
            this.Availability = technicalAvailability
                .ToString();
            this.State = technicalState
                .ToString();
        }
        public Technical
            (RegisterTechnicalCommand command)
        {
            this.Id = command.Id;
            this.SpecialtiesId = command.SpecialtyId;
            this.DistrictsId = command.DistrictId;
            this.ProfileUrl = command.ProfileUrl;
            this.Firstname = command.Firstname.ToUpper();
            this.Lastname = command.Lastname.ToUpper();
            this.Age = command.Age;
            this.Genre = command.Genre;
            this.Phone = command.Phone;
            this.Email = command.Email;
            this.Availability = command
                .TechnicalAvailability.ToString();
            this.State = command
                .TechnicalState.ToString();
        }
    }
}