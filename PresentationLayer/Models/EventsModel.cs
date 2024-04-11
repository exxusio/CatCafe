namespace PresentationLayer.Models
{
    public class ViewEvents
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public string description { get; set; } = null!;

        public byte[] photography { get; set; } = null!;

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }
    }

    public class EditEvents
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public string description { get; set; } = null!;

        public byte[] photography { get; set; } = null!;

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }
    }
}
