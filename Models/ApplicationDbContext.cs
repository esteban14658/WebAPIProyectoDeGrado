using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PG.Models.Entitys;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Code> Codes { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Recycler> Recyclers { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> UsersApp { get; set; }
        public DbSet<CollectionPoint> CollectionPoints { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Route> Routes { get; set; }
    }
}
