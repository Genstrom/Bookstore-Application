using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Bokhandel
{
    public partial class BokhandelContext : DbContext
    {
        public BokhandelContext()
        {
        }

        public BokhandelContext(DbContextOptions<BokhandelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Butiker> Butiker { get; set; }
        public virtual DbSet<Böcker> Böcker { get; set; }
        public virtual DbSet<Författare> Författare { get; set; }
        public virtual DbSet<FörfattareBöckerFörlag> FörfattareBöckerFörlag { get; set; }
        public virtual DbSet<Förlag> Förlag { get; set; }
        public virtual DbSet<Kunder> Kunder { get; set; }
        public virtual DbSet<LagerSaldo> LagerSaldo { get; set; }
        public virtual DbSet<OrderDetaljer> OrderDetaljer { get; set; }
        public virtual DbSet<Ordrar> Ordrar { get; set; }
        public virtual DbSet<TitlarPerFörfattare> TitlarPerFörfattare { get; set; }
        public virtual DbSet<ToppTioKunder> ToppTioKunder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=TOMMY;Database=Bokhandel;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Butiker>(entity =>
            {
                entity.ToTable("Butiker");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Namn)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Postnummer)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Stad)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Böcker>(entity =>
            {
                entity.HasKey(e => e.Isbn);

                entity.ToTable("Böcker");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(13)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Pris).HasColumnType("money");

                entity.Property(e => e.Språk)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Titel)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Utgivningsdatum).HasColumnType("date");
            });

            modelBuilder.Entity<Författare>(entity =>
            {
                entity.ToTable("Författare");

                entity.Property(e => e.FörfattareId).HasColumnName("FörfattareID");

                entity.Property(e => e.Efternamn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Födelsedatum).HasColumnType("date");

                entity.Property(e => e.Förnamn)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FörfattareBöckerFörlag>(entity =>
            {
                entity.HasKey(e => new { e.Isbn, e.FörfattareId, e.FörlagsId })
                    .HasName("PK_FörfattareBöcker");

                entity.ToTable("FörfattareBöckerFörlag");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(13)
                    .HasColumnName("ISBN");

                entity.Property(e => e.FörfattareId).HasColumnName("FörfattareID");

                entity.Property(e => e.FörlagsId).HasColumnName("FörlagsID");

                entity.HasOne(d => d.Författare)
                    .WithMany(p => p.FörfattareBöckerFörlags)
                    .HasForeignKey(d => d.FörfattareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FörfattareBöckerFörlag_Författare");

                entity.HasOne(d => d.Förlags)
                    .WithMany(p => p.FörfattareBöckerFörlags)
                    .HasForeignKey(d => d.FörlagsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FörfattareBöckerFörlag_Förlag");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.FörfattareBöckerFörlags)
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FörfattareBöckerFörlag_Böcker");
            });

            modelBuilder.Entity<Förlag>(entity =>
            {
                entity.HasKey(e => e.FörlagsId);

                entity.ToTable("Förlag");

                entity.Property(e => e.FörlagsId).HasColumnName("FörlagsID");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Kontaktperson)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Namn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Postnummer)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Stad)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Telefonnummer)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Kunder>(entity =>
            {
                entity.ToTable("Kunder");

                entity.Property(e => e.Id)
                    .HasMaxLength(11)
                    .HasColumnName("ID");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Efternamn)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Epostadress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Förnamn)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Postnummer)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Stad)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Telefonnummer)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<LagerSaldo>(entity =>
            {
                entity.HasKey(e => new { e.ButiksId, e.Isbn });

                entity.ToTable("LagerSaldo");

                entity.Property(e => e.ButiksId).HasColumnName("ButiksID");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(13)
                    .HasColumnName("ISBN");

                entity.HasOne(d => d.Butiks)
                    .WithMany(p => p.LagerSaldos)
                    .HasForeignKey(d => d.ButiksId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LagerSaldoButikerID");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.LagerSaldos)
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LagerSaldo_Böcker");
            });

            modelBuilder.Entity<OrderDetaljer>(entity =>
            {
                entity.ToTable("OrderDetaljer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Leveransdatum).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Orderdatum).HasColumnType("datetime");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.OrderDetaljers)
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetaljer_Böcker");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetaljers)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetaljer_Ordrar");
            });

            modelBuilder.Entity<Ordrar>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Ordrar");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Betalningssätt)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ButiksId).HasColumnName("ButiksID");

                entity.Property(e => e.KundId)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("KundID");

                entity.Property(e => e.Moms).HasColumnType("money");

                entity.Property(e => e.Totalbelopp).HasColumnType("money");

                entity.HasOne(d => d.Butiks)
                    .WithMany(p => p.Ordrars)
                    .HasForeignKey(d => d.ButiksId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ordrar_Butiker");

                entity.HasOne(d => d.Kund)
                    .WithMany(p => p.Ordrars)
                    .HasForeignKey(d => d.KundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ordrar_Kunder");
            });

            modelBuilder.Entity<TitlarPerFörfattare>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TitlarPerFörfattare");

                entity.Property(e => e.Lagervärde).HasMaxLength(4000);

                entity.Property(e => e.Namn).HasMaxLength(101);
            });

            modelBuilder.Entity<ToppTioKunder>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ToppTioKunder");

                entity.Property(e => e.AntalOrdrar).HasColumnName("Antal ordrar");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("ID");

                entity.Property(e => e.Namn)
                    .IsRequired()
                    .HasMaxLength(81);

                entity.Property(e => e.TotalbeloppInklMoms)
                    .HasColumnType("money")
                    .HasColumnName("Totalbelopp inkl. moms");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
