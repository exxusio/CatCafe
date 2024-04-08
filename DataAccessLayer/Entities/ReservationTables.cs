namespace DataAccessLayer.Entities
{
    public partial class ReservationTables
    {
        public int reservationTableID { get; set; }

        public int reservationID { get; set; }

        public int tableID { get; set; }

        public virtual Reservations reservation { get; set; } = null!;

        public virtual Tables table { get; set; } = null!;
    }
}