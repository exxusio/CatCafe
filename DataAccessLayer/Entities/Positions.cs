namespace DataAccessLayer.Entities
{
    public partial class Positions
    {
        public int positionID { get; set; }

        public string description { get; set; } = null!;

        public virtual ICollection<Employees> employee { get; set; } = new List<Employees>();
    }
}