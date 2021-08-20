using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Shop> Tiendas { get; set; }
        public DbSet<Recycler> Recicladores { get; set; }
        public DbSet<Resident> Residentes { get; set; }
        public DbSet<Address> Direcciones { get; set; }
        public DbSet<User> Usuarios { get; set; }
        public DbSet<CollectionPoint> PuntoDeRecolecciones { get; set; }
    }
}
