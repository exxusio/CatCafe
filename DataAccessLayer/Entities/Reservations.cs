namespace DataAccessLayer.Entities
{
    public partial class Reservations
    {
        public int reservationID { get; set; }

        public int visitorID { get; set; }

        public DateOnly reservationDate { get; set; }

        public TimeOnly reservationTime { get; set; }

        public virtual ICollection<ReservationCats> reservationCat { get; set; } = new List<ReservationCats>();

        public virtual ICollection<ReservationTables> table { get; set; } = new List<ReservationTables>();

        public virtual Visitors visitor { get; set; } = null!;
    }
}