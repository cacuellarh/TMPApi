

using Microsoft.EntityFrameworkCore;
using System.Xml;
using TPM.domain.entities;

namespace TMP.infraestructure.persistence
{
    public class DbContextTMP : DbContext
    {
        public DbContextTMP(DbContextOptions<DbContextTMP> options)
            : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseMySql("Server=195.35.14.162;Database=TMP;User=user;Password=P@ssW0rd;",
        //            new MySqlServerVersion(new Version(8, 0, 26)));
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageTrack>()
                .Property(e => e.DeleteSoft)
                .HasDefaultValue(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.DeleteSoft)
                .HasDefaultValue(false);

            modelBuilder.Entity<Product>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.PrecioActualEscaneado)
                .HasColumnType("decimal(18, 2)");

        }
        public DbSet<ImageTrack> ImageTracks { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
