namespace DataAccessLayer.Entities
{
    public partial class Contents
    {
        public int contentID { get; set; }

        public int orderID { get; set; }

        public int productID { get; set; }

        public int quantity { get; set; }

        public virtual Orders order { get; set; } = null!;

        public virtual Products product { get; set; } = null!;
    }
}