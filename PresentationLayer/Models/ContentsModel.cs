namespace PresentationLayer.Models
{
    public class ViewContents
    {
        public int ID { get; set; }

        public int orderID { get; set; }

        public ViewProducts product { get; set; } = null!;

        public int quantity { get; set; }
    }

    public class EditContents
    {
        public int ID { get; set; }

        public int orderID { get; set; }

        public int productID { get; set; }

        public int quantity { get; set; }
    }
}
