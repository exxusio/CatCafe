namespace DataAccessLayer.Entities
{
    public partial class Tables
    {
        public int ID { get; set; }

        public int number { get; set; }

        public int capacity { get; set; }

        public virtual ICollection<Orders> orders { get; set; } = new List<Orders>();

        public virtual ICollection<ReservationTables> reservationTables { get; set; } = new List<ReservationTables>();
    }
}