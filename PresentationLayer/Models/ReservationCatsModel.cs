namespace PresentationLayer.Models
{
    public class ViewReservationCats
    {
        public int ID { get; set; }

        public int reservationID { get; set; }

        public ViewCats cat { get; set; } = null!;
    }

    public class EditReservationCats
    {
        public int ID { get; set; }

        public int reservationID { get; set; }

        public int catID { get; set; }
    }
}
