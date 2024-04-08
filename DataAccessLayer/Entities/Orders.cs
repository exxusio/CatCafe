namespace DataAccessLayer.Entities
{
    public partial class Orders
    {
        public int orderID { get; set; }

        public int visitorID { get; set; }

        public int? tableID { get; set; }

        public DateOnly orderDate { get; set; }

        public TimeOnly orderTime { get; set; }

        public virtual ICollection<Contents> content { get; set; } = new List<Contents>();

        public virtual Tables? reservationTable { get; set; }

        public virtual Visitors visitor { get; set; } = null!;
    }
}