using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SinFTE.Models;

namespace SinFTE.Data.Map
{
    public class LogMap : IEntityTypeConfiguration<LogModel>
    {
        public void Configure(EntityTypeBuilder<LogModel> builder)
        {
            builder.HasKey(x => x.Id_log);


            builder.Property(x => x.Marcas).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Loja).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Mensagem).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Qte_off).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Qte_caixas).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Indica_erro).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Data_criacao).HasDefaultValueSql("GETDATE()");


    }
    }
}
