namespace DataAccessLayer.Entities
{
    public partial class Breeds
    {
        public int breedID { get; set; }

        public string name { get; set; } = null!;

        public string? description { get; set; }

        public virtual ICollection<Cats> cat { get; set; } = new List<Cats>();
    }
}