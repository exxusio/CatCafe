namespace PresentationLayer.Models
{
    public class ViewOrders
    {
        public int ID { get; set; }

        public int visitorID { get; set; }

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }

        public ICollection<ViewContents> contents { get; set; } = new List<ViewContents>();

        public ViewTables table { get; set; }
    }

    public class EditOrders
    {
        public int ID { get; set; }

        public int visitorID { get; set; }

        public int? tableID { get; set; }

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }
    }
}
