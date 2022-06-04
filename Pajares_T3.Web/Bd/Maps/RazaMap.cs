using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pajares_T3.Web.Models;
namespace Pajares_T3.Web.Bd.Maps
{
    public class RazaMap : IEntityTypeConfiguration<Raza>
    {
        public void Configure(EntityTypeBuilder<Raza> builder)
        {
            builder.ToTable("Raza");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Historial).
              WithOne(o => o.Razas).
              HasForeignKey(o => o.IdRaza);

        }
    }
}
