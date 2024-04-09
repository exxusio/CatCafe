namespace DataAccessLayer.Entities
{
    public partial class Cats
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public int breedID { get; set; }

        public byte[] photography { get; set; } = null!;

        public DateOnly dateOfBirth { get; set; }

        public string? descriptionCharacter { get; set; }

        public virtual Breeds breed { get; set; } = null!;

        public virtual ICollection<ReservationCats> reservationCats { get; set; } = new List<ReservationCats>();
    }
}