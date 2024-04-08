namespace DataAccessLayer.Entities
{
    public partial class Cats
    {
        public int catID { get; set; }

        public string name { get; set; } = null!;

        public int breedID { get; set; }

        public byte[] photography { get; set; } = null!;

        public DateOnly dateOfBirth { get; set; }

        public string? characterDescription { get; set; }

        public virtual Breeds breed { get; set; } = null!;

        public virtual ICollection<ReservationCats> reservationCat { get; set; } = new List<ReservationCats>();
    }
}