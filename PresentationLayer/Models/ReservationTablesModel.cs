namespace PresentationLayer.Models
{
    public class ViewReservationTables
    {
        public int ID { get; set; }

        public int reservationID { get; set; }

        public ViewTables table { get; set; } = null!;
    }

    public class EditReservationTables
    {
        public int ID { get; set; }

        public int reservationID { get; set; }

        public int tableID { get; set; }
    }
}
