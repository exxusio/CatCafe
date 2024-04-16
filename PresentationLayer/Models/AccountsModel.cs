namespace PresentationLayer.Models
{
    public class ViewAccounts
    {
        public int ID { get; set; }

        public ViewVisitors visitor { get; set; } = null!;

        public string login { get; set; } = null!;

        public string password { get; set; } = null!;

        public DateOnly registrationDate { get; set; }
    }

    public class EditAccounts
    {
        public int ID { get; set; }

        public int visitorID { get; set; }

        public string login { get; set; } = null!;

        public string password { get; set; } = null!;

        public DateOnly registrationDate { get; set; }
    }
}
