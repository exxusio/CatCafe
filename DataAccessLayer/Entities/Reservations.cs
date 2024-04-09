namespace DataAccessLayer.Entities
{
    public partial class Reservations
    {
        public int ID { get; set; }

        public int visitorID { get; set; }

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }

        public virtual ICollection<ReservationCats> reservationCats { get; set; } = new List<ReservationCats>();

        public virtual ICollection<ReservationTables> reservationTables { get; set; } = new List<ReservationTables>();

        public virtual Visitors visitor { get; set; } = null!;
    }
}