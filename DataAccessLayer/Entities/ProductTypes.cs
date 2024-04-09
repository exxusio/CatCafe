namespace DataAccessLayer.Entities
{
    public partial class ProductTypes
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public virtual ICollection<Products> products { get; set; } = new List<Products>();
    }
}