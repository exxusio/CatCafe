namespace DataAccessLayer.Entities
{
    public partial class Products
    {
        public int productID { get; set; }

        public string name { get; set; } = null!;

        public int typeID { get; set; }

        public string description { get; set; } = null!;

        public byte[] photography { get; set; } = null!;

        public decimal price { get; set; }

        public virtual ICollection<Contents> content { get; set; } = new List<Contents>();

        public virtual Types type { get; set; } = null!;
    }
}