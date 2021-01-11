using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolApp.Models;
#nullable disable

namespace SchoolApp.Data
{
    public partial class SchoolDBContext : DbContext
    {
        public SchoolDBContext()
        {
        }

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Adsence> Adsences { get; set; }
        public virtual DbSet<Departement> Departements { get; set; }
        public virtual DbSet<Element> Elements { get; set; }
        public virtual DbSet<Etudiant> Etudiants { get; set; }
        public virtual DbSet<Filliere> Fillieres { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Prof> Profs { get; set; }
        public virtual DbSet<Validation> Validations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SchoolDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .IsClustered(false);

                entity.ToTable("ADMIN");

                entity.Property(e => e.IdAdmin)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_ADMIN");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<Adsence>(entity =>
            {
                entity.HasKey(e => new { e.IdEtud, e.IdElem })
                    .IsClustered(false);

                entity.ToTable("ADSENCE");

                entity.Property(e => e.IdEtud)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_ETUD");

                entity.Property(e => e.IdElem)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_ELEM");

                entity.Property(e => e.DateAbs)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_ABS");

                entity.Property(e => e.IsJustif).HasColumnName("IS_JUSTIF");

                entity.Property(e => e.Justification)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("JUSTIFICATION");
            });

            modelBuilder.Entity<Departement>(entity =>
            {
                entity.HasKey(e => e.IdDep)
                    .IsClustered(false);

                entity.ToTable("DEPARTEMENT");

                entity.Property(e => e.IdDep)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_DEP");

                entity.Property(e => e.NomDep)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOM_DEP");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.HasKey(e => e.IdElem)
                    .IsClustered(false);

                entity.ToTable("ELEMENT");

                entity.Property(e => e.IdElem)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_ELEM");

                entity.Property(e => e.IdMod)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_MOD");

                entity.Property(e => e.IdProf)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_PROF");

                entity.Property(e => e.NomElem)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOM_ELEM");
            });

            modelBuilder.Entity<Etudiant>(entity =>
            {
                entity.HasKey(e => e.IdEtud)
                    .IsClustered(false);

                entity.ToTable("ETUDIANT");

                entity.Property(e => e.IdEtud)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_ETUD");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADRESSE");

                entity.Property(e => e.DateNaiss)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_NAISS");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.IdFill)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_FILL");

                entity.Property(e => e.Nom)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOM");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");


                entity.Property(e => e.Prenom)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PRENOM");

                entity.Property(e => e.Tel)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TEL");
            });

            modelBuilder.Entity<Filliere>(entity =>
            {
                entity.HasKey(e => e.IdFill)
                    .IsClustered(false);

                entity.ToTable("FILLIERE");

                entity.Property(e => e.IdFill)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_FILL");

                entity.Property(e => e.NomFill)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOM_FILL");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.IdMod)
                    .IsClustered(false);

                entity.ToTable("MODULE");

                entity.Property(e => e.IdMod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_MOD");

                entity.Property(e => e.IdFill)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_FILL");

                entity.Property(e => e.NomMod)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOM_MOD");

                entity.Property(e => e.Semestre)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SEMESTRE");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => new { e.IdEtud, e.IdElem })
                    .IsClustered(false);

                entity.ToTable("NOTE");

                entity.Property(e => e.IdEtud)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_ETUD");

                entity.Property(e => e.IdElem)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_ELEM");

                entity.Property(e => e.NoteAvRatt)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("NOTE_AV_RATT");

                entity.Property(e => e.NoteFinal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("NOTE_FINAL");

                entity.Property(e => e.NoteRatt)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("NOTE_RATT");
            });

            modelBuilder.Entity<Prof>(entity =>
            {
                entity.HasKey(e => e.IdProf)
                    .IsClustered(false);

                entity.ToTable("PROF");

                entity.Property(e => e.IdProf)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_PROF");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.IdDep)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_DEP");

                entity.Property(e => e.Nom)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOM");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Prenom)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PRENOM");

                entity.Property(e => e.Tel)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TEL");
            });

            modelBuilder.Entity<Validation>(entity =>
            {
                entity.HasKey(e => new { e.IdEtud, e.IdMod })
                    .IsClustered(false);

                entity.ToTable("VALIDATION");

                entity.Property(e => e.IdEtud)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_ETUD");

                entity.Property(e => e.IdMod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_MOD");

                entity.Property(e => e.NoteFinal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("NOTE_FINAL");

                entity.Property(e => e.Validation1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VALIDATION");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
