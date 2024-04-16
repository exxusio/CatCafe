namespace PresentationLayer.Models
{
    public class ViewReservations
    {
        public int ID { get; set; }

        public int visitorID { get; set; }

        public ICollection<ViewCats> cats { get; set; } = new List<ViewCats>();

        public ICollection<ViewTables> tables { get; set; } = new List<ViewTables>();

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }
    }

    public class EditReservations
    {
        public int ID { get; set; }

        public int visitorID { get; set; }

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }
    }
}
