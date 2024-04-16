namespace PresentationLayer.Models
{
    public class ViewCats
    {
        public int ID { get; set; }

        public byte[] photography { get; set; } = null!;

        public string name { get; set; } = null!;

        public DateOnly dateOfBirth { get; set; }

        public ViewBreeds breed { get; set; } = null!;

        public string? descriptionCharacter { get; set; }
    }

    public class EditCats
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public int breedID { get; set; }

        public byte[] photography { get; set; } = null!;

        public DateOnly dateOfBirth { get; set; }

        public string? descriptionCharacter { get; set; }
    }
}
