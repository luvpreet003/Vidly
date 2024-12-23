using System.Data.Entity;
using Vidly.Models;

namespace Vidly
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection") // Connection string name in Web.config or appsettings.json
        {

        }

        // Add DbSet properties for your entities
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
