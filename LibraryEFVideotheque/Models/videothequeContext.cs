using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LibraryEFVideotheque.Models
{
    public partial class videothequeContext : DbContext
    {
        public videothequeContext()
        {
        }

        public videothequeContext(DbContextOptions<videothequeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artiste> Artistes { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Internaute> Internautes { get; set; }
        public virtual DbSet<Notation> Notations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=192.168.6.128;database=videotheque;uid=adminbs;pwd=abcd4ABCD", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Artiste>(entity =>
            {
                entity.ToTable("artiste");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_general_ci");

                entity.HasIndex(e => new { e.Nom, e.Prenom }, "UniqueNomArtiste")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnneeNaissance).HasColumnName("anneeNaissance");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nom");

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("prenom");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("film");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_general_ci");

                entity.HasIndex(e => e.CodePays, "codePays");

                entity.HasIndex(e => e.IdGenre, "genre");

                entity.HasIndex(e => e.IdRealisateur, "idRealisateur");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Annee).HasColumnName("annee");

                entity.Property(e => e.CodePays)
                    .HasMaxLength(4)
                    .HasColumnName("codePays");

                entity.Property(e => e.IdGenre).HasColumnName("idGenre");

                entity.Property(e => e.IdRealisateur).HasColumnName("idRealisateur");

                entity.Property(e => e.Resume)
                    .HasColumnType("text")
                    .HasColumnName("resume");

                entity.Property(e => e.Titre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("titre");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("film_ibfk_2");

                entity.HasOne(d => d.IdRealisateurNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdRealisateur)
                    .HasConstraintName("film_ibfk_1");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nom");
            });

            modelBuilder.Entity<Internaute>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PRIMARY");

                entity.ToTable("internaute");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_general_ci");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .HasColumnName("email");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nom");

                entity.Property(e => e.Password)
                    .HasMaxLength(80)
                    .HasColumnName("password");

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("prenom");

                entity.Property(e => e.Region)
                    .HasMaxLength(30)
                    .HasColumnName("region");

                entity.Property(e => e.Roles)
                    .HasMaxLength(60)
                    .HasColumnName("roles");

                entity.Property(e => e.Salt)
                    .HasMaxLength(50)
                    .HasColumnName("salt");
            });

            modelBuilder.Entity<Notation>(entity =>
            {
                entity.ToTable("notation");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_general_ci");

                entity.HasIndex(e => e.Email, "email");

                entity.HasIndex(e => new { e.IdFilm, e.Email }, "idFilm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("email");

                entity.Property(e => e.IdFilm).HasColumnName("idFilm");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Notations)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notation_ibfk_2");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Notations)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notation_ibfk_1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_general_ci");

                entity.HasIndex(e => e.IdActeur, "idActeur");

                entity.HasIndex(e => new { e.IdFilm, e.IdActeur }, "idFilm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdActeur).HasColumnName("idActeur");

                entity.Property(e => e.IdFilm).HasColumnName("idFilm");

                entity.Property(e => e.Role1)
                    .HasMaxLength(30)
                    .HasColumnName("role");

                entity.HasOne(d => d.IdActeurNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.IdActeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_ibfk_2");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
