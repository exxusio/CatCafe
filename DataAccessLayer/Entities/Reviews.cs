namespace DataAccessLayer.Entities
{
    public partial class Reviews
    {
        public int reviewID { get; set; }

        public int visitorID { get; set; }

        public string? reviewText { get; set; }

        public DateOnly reviewDate { get; set; }

        public TimeOnly reviewTime { get; set; }

        public int rating { get; set; }

        public virtual Visitors visitor { get; set; } = null!;
    }
}