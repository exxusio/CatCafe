namespace DataAccessLayer.Entities
{
    public partial class Visitors
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public string surname { get; set; } = null!;

        public string phoneNumber { get; set; } = null!;

        public string? emailAddress { get; set; }

        public DateOnly dateOfBirth { get; set; }

        public virtual Accounts? account { get; set; }

        public virtual ICollection<Orders> orders { get; set; } = new List<Orders>();

        public virtual ICollection<Reservations> reservations { get; set; } = new List<Reservations>();

        public virtual ICollection<Reviews> reviews { get; set; } = new List<Reviews>();
    }
}