using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pajares_T3.Web.Models;
namespace Pajares_T3.Web.Bd.Maps
{
    public class SexoMap : IEntityTypeConfiguration<Sexo>
    {
        public void Configure(EntityTypeBuilder<Sexo> builder)
        {
            builder.ToTable("Sexo");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Historial).
              WithOne(o => o.Sexos).
              HasForeignKey(o => o.IdSexo);


        }
    }
}
