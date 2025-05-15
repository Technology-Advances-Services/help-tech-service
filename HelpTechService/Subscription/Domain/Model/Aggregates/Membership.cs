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

        public Membership()
        {
            this.Name = string.Empty;
            this.Price = 0;
            this.Policies = string.Empty;
            this.State = string.Empty;
        }
        public Membership
            (int id, string name, decimal price,
            string policies, string state)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Policies = policies;
            this.State = state;
        }
    }
}