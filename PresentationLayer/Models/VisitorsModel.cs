namespace PresentationLayer.Models
{
    public class ViewVisitors
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public string surname { get; set; } = null!;

        public string phoneNumber { get; set; } = null!;

        public string? emailAddress { get; set; }

        public DateOnly dateOfBirth { get; set; }

        public ICollection<ViewOrders> orders { get; set; } = new List<ViewOrders>();

        public ICollection<ViewReservations> reservations { get; set; } = new List<ViewReservations>();
    }

    public class EditVisitors
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public string surname { get; set; } = null!;

        public string phoneNumber { get; set; } = null!;

        public string? emailAddress { get; set; }

        public DateOnly dateOfBirth { get; set; }
    }
}
