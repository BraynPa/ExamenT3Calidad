using Microsoft.EntityFrameworkCore;
using Pajares_T3.Web.Bd.Maps;
using Pajares_T3.Web.Models;

namespace Pajares_T3.Web.Bd
{
    public interface IVeterinariaContext
    {
        DbSet<Usuario> _usuario { get; set; }
        DbSet<Especie> _especie { get; set; }
        DbSet<Raza> _raza { get; set; }
        DbSet<Sexo> _sexo { get; set; }
        DbSet<Historial> _historial { get; set; }

        int SaveChanges();

    }
    public class VeterinariaContext : DbContext, IVeterinariaContext
    {

        public DbSet<Usuario> _usuario { get; set; }
        public DbSet<Especie> _especie { get; set; }
        public DbSet<Raza> _raza { get; set; }
        public DbSet<Sexo> _sexo { get; set; }
        public DbSet<Historial> _historial { get; set; }

        public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EspecieMap());
            modelBuilder.ApplyConfiguration(new RazaMap());
            modelBuilder.ApplyConfiguration(new SexoMap());
            modelBuilder.ApplyConfiguration(new HistorialMap());
        }
    }
}
