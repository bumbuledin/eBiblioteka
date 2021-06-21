using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public partial class eBibliotekaContext : DbContext
    {
        public eBibliotekaContext(DbContextOptions<eBibliotekaContext> options) : base(options) { }

        public virtual DbSet<Clan> Clan { get; set; }
        public virtual DbSet<Clan> Grad { get; set; }
        public virtual DbSet<Uposlenik> Uposlenik { get; set; }
        public virtual DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public virtual DbSet<UposlenikUloga> UposlenikUloga { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<Uplata> Uplata { get; set; }
        public virtual DbSet<VrstaUplate> VrstaUplate { get; set; }
        public virtual DbSet<Izdavac> Izdavac { get; set; }
        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<Knjiga> Knjiga { get; set; }
        public virtual DbSet<Zaduzenje> Zaduzenje { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clan>(entity => 
            {
                entity.Property(e => e.Status)
                .HasDefaultValue(true);

                entity.HasOne(s => s.Grad)
                .WithMany(d => d.Clanovi)
                .HasForeignKey(s => s.GradId)
                .HasConstraintName("FK_Clan_Grad")
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Uposlenik>(entity =>
            {
                entity.Property(e => e.Status)
                .HasDefaultValue(true);

                entity.HasOne(s => s.Grad)
                .WithMany(d => d.Uposlenici)
                .HasForeignKey(s => s.GradId)
                .HasConstraintName("FK_Uposlenik_Grad")
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<KorisnickiNalog>(entity =>
            {
                entity.Property(e => e.Status)
                .HasDefaultValue(true);
            });

            modelBuilder.Entity<Uplata>(entity =>
            {
                entity.Property(s => s.IznosUplate).HasColumnType("decimal(18,2)");

                entity.HasOne(d => d.Clan)
                .WithMany(b => b.Uplate)
                .HasForeignKey(d => d.ClanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Uplata_Clan");

                entity.HasOne(d => d.VrstaUplate)
                .WithMany(b => b.Uplate)
                .HasForeignKey(d => d.VrstaUplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Uplata_VrstaUplate");

            });

            modelBuilder.Entity<Zaduzenje>(entity =>
            {
                entity.Property(e => e.Status)
               .HasDefaultValue(true);

                entity.HasOne(d => d.Clan)
                .WithMany(b => b.Zaduzenja)
                .HasForeignKey(d => d.ClanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zaduzenja_Clan");

                entity.HasOne(d => d.Knjiga)
                .WithMany(b => b.Zaduzenja)
                .HasForeignKey(d => d.KnjigaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zaduzenje_Knjiga");
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.Property(e => e.Status)
               .HasDefaultValue(true);

                entity.HasOne(d => d.Clan)
                .WithMany(b => b.Rezervacije)
                .HasForeignKey(d => d.ClanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rezervacija_Clan");

                entity.HasOne(d => d.Knjiga)
                .WithMany(b => b.Rezervacije)
                .HasForeignKey(d => d.KnjigaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rezervacija_Knjiga");
            });

            modelBuilder.Entity<Knjiga>(entity =>
            {
                entity.Property(e => e.Status)
                .HasDefaultValue(true);

                entity.HasOne(d => d.Autor)
                .WithMany(b => b.Knjige)
                .HasForeignKey(d => d.AutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Knjiga_Autor");

                entity.HasOne(d => d.Izdavac)
                .WithMany(b => b.Knjige)
                .HasForeignKey(d => d.IzdavacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Knjiga_Izdavac");

                entity.HasOne(d => d.Kategorija)
               .WithMany(b => b.Knjige)
               .HasForeignKey(d => d.KategorijaId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Knjiga_Kategorija");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
