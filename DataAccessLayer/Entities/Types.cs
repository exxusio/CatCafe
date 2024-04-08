namespace DataAccessLayer.Entities
{
    public partial class Types
    {
        public int typeID { get; set; }

        public string typeName { get; set; } = null!;

        public virtual ICollection<Products> product { get; set; } = new List<Products>();
    }
}