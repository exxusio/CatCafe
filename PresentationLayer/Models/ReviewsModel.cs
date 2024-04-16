namespace PresentationLayer.Models
{
    public class ViewReviews
    {
        public int ID { get; set; }

        public ViewVisitors visitor { get; set; } = null!;

        public string? text { get; set; }

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }

        public int rating { get; set; }
    }

    public class EditReviews
    {
        public int ID { get; set; }

        public int visitorID { get; set; }

        public string? text { get; set; }

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }

        public int rating { get; set; }
    }
}
