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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Recycler> Recyclers { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> UsersApp { get; set; }
        public DbSet<CollectionPoint> CollectionPoints { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Route> Routes { get; set; }
    }
}
