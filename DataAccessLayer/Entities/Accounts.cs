namespace DataAccessLayer.Entities
{
    public partial class Accounts
    {
        public int ID { get; set; }

        public int visitorID { get; set; }

        public string login { get; set; } = null!;

        public string password { get; set; } = null!;

        public DateOnly registrationDate { get; set; }

        public virtual Visitors visitor { get; set; } = null!;
    }
}