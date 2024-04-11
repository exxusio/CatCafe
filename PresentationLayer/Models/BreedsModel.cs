namespace PresentationLayer.Models
{
    public class ViewBreeds
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public string? description { get; set; }
    }

    public class EditBreeds
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public string? description { get; set; }
    }
}
