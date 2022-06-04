using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pajares_T3.Web.Models;
namespace Pajares_T3.Web.Bd.Maps
{
    public class EspecieMap : IEntityTypeConfiguration<Especie>
    {
        public void Configure(EntityTypeBuilder<Especie> builder)
        {
            builder.ToTable("Especie");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Historial).
              WithOne(o => o.Especies).
              HasForeignKey(o => o.IdEspecie);


        }
    }
}
