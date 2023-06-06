using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SinFTE.Data.Map;
using SinFTE.Models;

namespace SinFTE.Data
{
    public class SinFTEDBContext : IdentityDbContext
    {
        public SinFTEDBContext(DbContextOptions<SinFTEDBContext> options)
            : base(options)
        {

        }

        public DbSet<LogCard> LOGCARD { get; set; }
        public DbSet<LogModel> LOG { get; set; }
        public DbSet<UserModel> USUARIOS { get; set; }
        public DbSet<MarcaModel> MARCAS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new MarcaMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
