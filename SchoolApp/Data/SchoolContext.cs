using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolApp.Models;
#nullable disable

namespace SchoolApp.Data
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
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
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=schoolbd", x => x.ServerVersion("10.4.10-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PRIMARY");

                entity.ToTable("admin");

                entity.Property(e => e.IdAdmin)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_ADMIN")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("PASSWORD")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Username)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("USERNAME")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Adsence>(entity =>
            {
                entity.HasKey(e => new { e.IdEtud, e.IdElem, e.DateAbs })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("adsence");

                entity.HasIndex(e => e.IdElem, "FK_ADSENCE");

                entity.Property(e => e.IdEtud)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_ETUD")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdElem)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_ELEM")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DateAbs)
                    .HasColumnType("date")
                    .HasColumnName("DATE_ABS");

                entity.Property(e => e.IsJustif).HasColumnName("IS_JUSTIF");

                entity.Property(e => e.Justification)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("JUSTIFICATION")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Departement>(entity =>
            {
                entity.HasKey(e => e.IdDep)
                    .HasName("PRIMARY");

                entity.ToTable("departement");

                entity.Property(e => e.IdDep)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_DEP")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NomDep)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("NOM_DEP")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.HasKey(e => e.IdElem)
                    .HasName("PRIMARY");

                entity.ToTable("element");

                entity.HasIndex(e => e.IdMod, "FK_ELEM_DE_MOD");

                entity.HasIndex(e => e.IdProf, "FK_ENSEIGNE");

                entity.Property(e => e.IdElem)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_ELEM")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdMod)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_MOD")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdProf)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_PROF")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NomElem)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("NOM_ELEM")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Etudiant>(entity =>
            {
                entity.HasKey(e => e.IdEtud)
                    .HasName("PRIMARY");

                entity.ToTable("etudiant");

                entity.HasIndex(e => e.IdFill, "FK_FILL_DE_ETUDIANT");

                entity.Property(e => e.IdEtud)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_ETUD")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Adresse)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("ADRESSE")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DateNaiss)
                    .HasColumnType("date")
                    .HasColumnName("DATE_NAISS");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("EMAIL")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdFill)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_FILL")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Nom)
                    .HasColumnType("varchar(30)")
                    .HasColumnName("NOM")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("PASSWORD")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Photo).HasColumnName("PHOTO");

                entity.Property(e => e.Prenom)
                    .HasColumnType("varchar(30)")
                    .HasColumnName("PRENOM")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Tel)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("TEL")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Filliere>(entity =>
            {
                entity.HasKey(e => e.IdFill)
                    .HasName("PRIMARY");

                entity.ToTable("filliere");

                entity.HasIndex(e => e.IdChef, "FK_CHEF");

                entity.Property(e => e.IdFill)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_FILL")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdChef)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_CHEF")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NomFill)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("NOM_FILL")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.IdMod)
                    .HasName("PRIMARY");

                entity.ToTable("module");

                entity.HasIndex(e => e.IdFill, "FK_MOD_DE_FILL");

                entity.Property(e => e.IdMod)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_MOD")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdFill)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_FILL")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NomMod)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("NOM_MOD")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Semestre)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("SEMESTRE")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => new { e.IdEtud, e.IdElem })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("note");

                entity.HasIndex(e => e.IdElem, "FK_NOTE");

                entity.Property(e => e.IdEtud)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_ETUD")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdElem)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_ELEM")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NoteAvRatt)
                    .HasPrecision(10)
                    .HasColumnName("NOTE_AV_RATT");

                entity.Property(e => e.NoteFinal)
                    .HasPrecision(10)
                    .HasColumnName("NOTE_FINAL");

                entity.Property(e => e.NoteRatt)
                    .HasPrecision(10)
                    .HasColumnName("NOTE_RATT");
            });

            modelBuilder.Entity<Prof>(entity =>
            {
                entity.HasKey(e => e.IdProf)
                    .HasName("PRIMARY");

                entity.ToTable("prof");

                entity.HasIndex(e => e.IdDep, "FK_DEP_DE_PROF");

                entity.Property(e => e.IdProf)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_PROF")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("EMAIL")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdDep)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_DEP")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Nom)
                    .HasColumnType("varchar(30)")
                    .HasColumnName("NOM")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("PASSWORD")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Prenom)
                    .HasColumnType("varchar(30)")
                    .HasColumnName("PRENOM")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Tel)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("TEL")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Validation>(entity =>
            {
                entity.HasKey(e => new { e.IdEtud, e.IdMod })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("validation");

                entity.HasIndex(e => e.IdMod, "FK_VALIDATION");

                entity.Property(e => e.IdEtud)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_ETUD")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdMod)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("ID_MOD")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NoteFinal)
                    .HasPrecision(10)
                    .HasColumnName("NOTE_FINAL");

                entity.Property(e => e.Validation1)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("VALIDATION")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
