using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProCrib.Domain.Models;

namespace ProCrib.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Property> Properties { get; set; }

        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Advert> Adverts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        { }
    }
}
