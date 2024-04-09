namespace DataAccessLayer.Entities
{
    public partial class Breeds
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public string? description { get; set; }

        public virtual ICollection<Cats> cats { get; set; } = new List<Cats>();
    }
}