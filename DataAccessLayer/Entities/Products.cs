namespace DataAccessLayer.Entities
{
    public partial class Products
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public int typeID { get; set; }

        public string description { get; set; } = null!;

        public byte[] photography { get; set; } = null!;

        public decimal price { get; set; }

        public virtual ICollection<Contents> contents { get; set; } = new List<Contents>();

        public virtual ProductTypes type { get; set; } = null!;
    }
}