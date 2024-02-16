using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCSite.Data
{
    public class CurrentContext : IdentityDbContext<User>
    {
        public CurrentContext(DbContextOptions<CurrentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
