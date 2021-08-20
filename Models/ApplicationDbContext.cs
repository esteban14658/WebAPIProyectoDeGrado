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

        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Reciclador> Recicladores { get; set; }
        public DbSet<Residente> Residentes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PuntoDeRecoleccion> PuntoDeRecolecciones { get; set; }
    }
}
