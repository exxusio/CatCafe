using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities
{
    public partial class Accounts : IdentityUser<int>
    {
        public int visitorID { get; set; }  

        public string password { get; set; } = null!;

        public DateOnly registrationDate { get; set; }

        public virtual Visitors visitor { get; set; } = null!;
    }
}