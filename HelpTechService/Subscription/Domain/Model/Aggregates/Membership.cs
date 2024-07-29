namespace HelpTechService.Subscription.Domain.Model.Aggregates
{
    public class Membership
    {
        public int Id { get; }
        public string Name { get; private set; } = null!;
        public decimal Price { get; private set; }
        public string Policies { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual ICollection<Contract> Contracts { get; } = [];
    }
}