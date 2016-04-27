using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace UniversityManagementApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("universityManagementDBConnectionString")
        {
        }
    }

    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext()
            : base("universityManagementDBConnectionString")
        {
        }
        public DbSet<Users> users { get; set; }
    }
}