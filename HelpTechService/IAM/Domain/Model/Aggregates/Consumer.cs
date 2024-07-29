using HelpTechService.Attention.Domain.Model.Aggregates;
using HelpTechService.Attention.Domain.Model.Entities;
using HelpTechService.Interaction.Domain.Model.Aggregates;
using HelpTechService.IAM.Domain.Model.Entities;
using HelpTechService.Location.Domain.Model.Aggregates;
using HelpTechService.Subscription.Domain.Model.Aggregates;

namespace HelpTechService.IAM.Domain.Model.Aggregates
{
    public class Consumer
    {
        public int Id { get; private set; }
        public int DistrictsId { get; private set; }
        public string ProfileUrl { get; private set; } = null!;
        public string Firstname { get; private set; } = null!;
        public string Lastname { get; private set; } = null!;
        public int Age { get; private set; }
        public string Genre { get; private set; } = null!;
        public int Phone { get; private set; }
        public string Email { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual ConsumerCredential? ConsumerCredential { get; }
        public virtual District District { get; } = null!;

        public virtual ICollection<Contract> Contracts { get; } = [];
        public virtual ICollection<Chat> Chats { get; } = [];
        public virtual ICollection<Job> Jobs { get; } = [];
        public virtual ICollection<Review> Reviews { get; } = [];
    }
}