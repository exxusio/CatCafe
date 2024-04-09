namespace DataAccessLayer.Entities
{
    public partial class Positions
    {
        public int ID { get; set; }

        public string description { get; set; } = null!;

        public virtual ICollection<Employees> employees { get; set; } = new List<Employees>();
    }
}