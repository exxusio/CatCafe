namespace DataAccessLayer.Entities
{
    public partial class Reviews
    {
        public int ID { get; set; }

        public int visitorID { get; set; }

        public string? text { get; set; }

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }

        public int rating { get; set; }

        public virtual Visitors visitor { get; set; } = null!;
    }
}