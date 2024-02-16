using Microsoft.AspNetCore.Identity;

namespace MVCSite.Data
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int Year { get; set; }
    }
}
