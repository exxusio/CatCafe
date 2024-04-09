namespace DataAccessLayer.Entities
{
    public partial class Orders
    {
        public int ID { get; set; }

        public int visitorID { get; set; }

        public int? tableID { get; set; }

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }

        public virtual ICollection<Contents> contents { get; set; } = new List<Contents>();

        public virtual Tables? table { get; set; }

        public virtual Visitors visitor { get; set; } = null!;
    }
}