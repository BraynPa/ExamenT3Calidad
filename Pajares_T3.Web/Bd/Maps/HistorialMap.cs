using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pajares_T3.Web.Models;
namespace Pajares_T3.Web.Bd.Maps
{
    public class HistorialMap : IEntityTypeConfiguration<Historial>
    {
        public void Configure(EntityTypeBuilder<Historial> builder)
        {
            builder.ToTable("Historial");
            builder.HasKey(o => o.CodigoRegistro);


        }
    }
}
