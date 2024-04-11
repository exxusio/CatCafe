namespace PresentationLayer.Models
{
    public class ViewContents
    {
        public int ID { get; set; }

        public int orderID { get; set; }

        public int quantity { get; set; }

        public ViewProducts product { get; set; } = null!;
    }

    public class EditContents
    {
        public int ID { get; set; }

        public int orderID { get; set; }

        public int productID { get; set; }

        public int quantity { get; set; }
    }
}
