namespace PresentationLayer.Models
{
    public class ViewProducts
    {
        public int ID { get; set; }

        public byte[] photography { get; set; } = null!;

        public string name { get; set; } = null!;

        public string description { get; set; } = null!;

        public decimal price { get; set; }

        public ViewProductTypes type { get; set; } = null!;
    }

    public class EditProducts
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public int typeID { get; set; }

        public string description { get; set; } = null!;

        public byte[] photography { get; set; } = null!;

        public decimal price { get; set; }
    }
}
