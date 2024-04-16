namespace PresentationLayer.Models
{
    public class ViewEmployees
    {
        public int ID { get; set; }

        public byte[] photography { get; set; } = null!;

        public string name { get; set; } = null!;

        public string surname { get; set; } = null!;

        public string? about { get; set; }

        public ViewPositions position { get; set; } = null!;

        public decimal salary { get; set; }

        public DateOnly hireDate { get; set; }
    }

    public class EditEmployees
    {
        public int ID { get; set; }

        public string name { get; set; } = null!;

        public string surname { get; set; } = null!;

        public int positionID { get; set; }

        public string? about { get; set; }

        public byte[] photography { get; set; } = null!;

        public decimal salary { get; set; }

        public DateOnly hireDate { get; set; }
    }
}
