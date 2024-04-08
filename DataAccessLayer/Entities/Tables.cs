namespace DataAccessLayer.Entities
{
    public partial class Tables
    {
        public int tableID { get; set; }

        public int tableNumber { get; set; }

        public int capacity { get; set; }

        public virtual ICollection<Orders> orders { get; set; } = new List<Orders>();

        public virtual ICollection<ReservationTables> reservationTable { get; set; } = new List<ReservationTables>();
    }
}