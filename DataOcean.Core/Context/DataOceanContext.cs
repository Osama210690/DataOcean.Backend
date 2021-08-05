using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataOcean.Core.Domain;

#nullable disable

namespace DataOcean.Core.Context
{
    public partial class DataOceanContext : DbContext
    {
        public DataOceanContext()
        {
        }

        public DataOceanContext(DbContextOptions<DataOceanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=172.16.110.46;Database=DataOcean;User=sa;Password=reallyStrongPwd123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.City_Code);

                entity.ToTable("City");

                entity.Property(e => e.City_Name_Arabic).HasMaxLength(50);

                entity.Property(e => e.City_Name_English)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created_Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Updated_Date)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Country_CodeNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.Country_Code)
                    .HasConstraintName("FK_City_Country");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Country_Code);

                entity.ToTable("Country");

                entity.Property(e => e.Country_Name_Arabic).HasMaxLength(50);

                entity.Property(e => e.Country_Name_English)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created_Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Updated_Date)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
