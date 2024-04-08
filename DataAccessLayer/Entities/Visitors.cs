namespace DataAccessLayer.Entities
{
    public partial class Visitors
    {
        public int visitorID { get; set; }

        public string name { get; set; } = null!;

        public string surname { get; set; } = null!;

        public string phoneNumber { get; set; } = null!;

        public string? emailAddress { get; set; }

        public DateOnly dateOfBirth { get; set; }

        public virtual Accounts? account { get; set; }

        public virtual ICollection<Orders> order { get; set; } = new List<Orders>();

        public virtual ICollection<Reservations> reservation { get; set; } = new List<Reservations>();

        public virtual ICollection<Reviews> review { get; set; } = new List<Reviews>();
    }
}