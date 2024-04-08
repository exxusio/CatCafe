namespace DataAccessLayer.Entities
{
    public partial class Events
    {
        public int eventID { get; set; }

        public string name { get; set; } = null!;

        public string description { get; set; } = null!;

        public byte[] photography { get; set; } = null!;

        public DateOnly eventDate { get; set; }

        public TimeOnly eventTime { get; set; }
    }
}