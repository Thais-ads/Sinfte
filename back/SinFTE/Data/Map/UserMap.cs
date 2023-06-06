using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SinFTE.Models;

namespace SinFTE.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id_usuario);
            builder.Property(x => x.Nome_completo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Inativo).IsRequired().HasMaxLength(1);
        }
    }
}
