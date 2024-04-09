namespace DataAccessLayer.Entities
{
    public partial class ReservationCats
    {
        public int ID { get; set; }

        public int reservationID { get; set; }

        public int catID { get; set; }

        public virtual Cats cat { get; set; } = null!;

        public virtual Reservations reservation { get; set; } = null!;
    }
}