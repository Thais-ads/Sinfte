using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SinFTE.Models;

namespace SinFTE.Data.Map
{
    public class MarcaMap : IEntityTypeConfiguration<MarcaModel>
    {
        public void Configure(EntityTypeBuilder<MarcaModel> builder)
        {
            builder.HasKey(x => x.Id_marca);
            builder.Property(x => x.Marca).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Lojas).IsRequired().HasMaxLength(255);
        }
    }
}
