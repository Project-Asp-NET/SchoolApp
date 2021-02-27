using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADMIN",
                columns: table => new
                {
                    ID_ADMIN = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    USERNAME = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PASSWORD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN", x => x.ID_ADMIN)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTEMENT",
                columns: table => new
                {
                    ID_DEP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NOM_DEP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTEMENT", x => x.ID_DEP)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PROF",
                columns: table => new
                {
                    ID_PROF = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID_DEP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NOM = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    PRENOM = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TEL = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    ID_FILL = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROF", x => x.ID_PROF)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_DEP_DE_PROF",
                        column: x => x.ID_DEP,
                        principalTable: "DEPARTEMENT",
                        principalColumn: "ID_DEP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FILLIERE",
                columns: table => new
                {
                    ID_FILL = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID_PROF = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NOM_FILL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILLIERE", x => x.ID_FILL)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_FILLIERE_PROF_ID_PROF",
                        column: x => x.ID_PROF,
                        principalTable: "PROF",
                        principalColumn: "ID_PROF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ETUDIANT",
                columns: table => new
                {
                    ID_ETUD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID_FILL = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NOM = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    PRENOM = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TEL = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    DATE_NAISS = table.Column<DateTime>(type: "datetime", nullable: true),
                    ADRESSE = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETUDIANT", x => x.ID_ETUD)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_FILL_DE_ETUDIANT",
                        column: x => x.ID_FILL,
                        principalTable: "FILLIERE",
                        principalColumn: "ID_FILL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MODULE",
                columns: table => new
                {
                    ID_MOD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID_FILL = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NOM_MOD = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SEMESTRE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODULE", x => x.ID_MOD)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_MOD_DE_FILL",
                        column: x => x.ID_FILL,
                        principalTable: "FILLIERE",
                        principalColumn: "ID_FILL",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ELEMENT",
                columns: table => new
                {
                    ID_ELEM = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID_MOD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID_PROF = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NOM_ELEM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ELEMENT", x => x.ID_ELEM)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ELEM_DE_MOD",
                        column: x => x.ID_MOD,
                        principalTable: "MODULE",
                        principalColumn: "ID_MOD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ENSEIGNE",
                        column: x => x.ID_PROF,
                        principalTable: "PROF",
                        principalColumn: "ID_PROF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VALIDATION",
                columns: table => new
                {
                    ID_ETUD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID_MOD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    VALIDATION = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    NOTE_FINAL = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VALIDATION", x => new { x.ID_ETUD, x.ID_MOD })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_VALIDATION",
                        column: x => x.ID_MOD,
                        principalTable: "MODULE",
                        principalColumn: "ID_MOD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VALIDATION2",
                        column: x => x.ID_ETUD,
                        principalTable: "ETUDIANT",
                        principalColumn: "ID_ETUD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ABSENCE",
                columns: table => new
                {
                    ID_ETUD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID_ELEM = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    DATE_ABS = table.Column<DateTime>(type: "datetime", nullable: true),
                    IS_JUSTIF = table.Column<bool>(type: "bit", nullable: true),
                    JUSTIFICATION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADSENCE", x => new { x.ID_ETUD, x.ID_ELEM })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ABSENCE",
                        column: x => x.ID_ELEM,
                        principalTable: "ELEMENT",
                        principalColumn: "ID_ELEM",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ABSENCE2",
                        column: x => x.ID_ETUD,
                        principalTable: "ETUDIANT",
                        principalColumn: "ID_ETUD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NOTE",
                columns: table => new
                {
                    ID_ETUD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ID_ELEM = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NOTE_AV_RATT = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    NOTE_RATT = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    NOTE_FINAL = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTE", x => new { x.ID_ETUD, x.ID_ELEM })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_NOTE",
                        column: x => x.ID_ELEM,
                        principalTable: "ELEMENT",
                        principalColumn: "ID_ELEM",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTE2",
                        column: x => x.ID_ETUD,
                        principalTable: "ETUDIANT",
                        principalColumn: "ID_ETUD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ABSENCE_ID_ELEM",
                table: "ABSENCE",
                column: "ID_ELEM");

            migrationBuilder.CreateIndex(
                name: "IX_ELEMENT_ID_MOD",
                table: "ELEMENT",
                column: "ID_MOD");

            migrationBuilder.CreateIndex(
                name: "IX_ELEMENT_ID_PROF",
                table: "ELEMENT",
                column: "ID_PROF");

            migrationBuilder.CreateIndex(
                name: "IX_ETUDIANT_ID_FILL",
                table: "ETUDIANT",
                column: "ID_FILL");

            migrationBuilder.CreateIndex(
                name: "IX_FILLIERE_ID_PROF",
                table: "FILLIERE",
                column: "ID_PROF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MODULE_ID_FILL",
                table: "MODULE",
                column: "ID_FILL");

            migrationBuilder.CreateIndex(
                name: "IX_NOTE_ID_ELEM",
                table: "NOTE",
                column: "ID_ELEM");

            migrationBuilder.CreateIndex(
                name: "IX_PROF_ID_DEP",
                table: "PROF",
                column: "ID_DEP");

            migrationBuilder.CreateIndex(
                name: "IX_VALIDATION_ID_MOD",
                table: "VALIDATION",
                column: "ID_MOD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ABSENCE");

            migrationBuilder.DropTable(
                name: "ADMIN");

            migrationBuilder.DropTable(
                name: "NOTE");

            migrationBuilder.DropTable(
                name: "VALIDATION");

            migrationBuilder.DropTable(
                name: "ELEMENT");

            migrationBuilder.DropTable(
                name: "ETUDIANT");

            migrationBuilder.DropTable(
                name: "MODULE");

            migrationBuilder.DropTable(
                name: "FILLIERE");

            migrationBuilder.DropTable(
                name: "PROF");

            migrationBuilder.DropTable(
                name: "DEPARTEMENT");
        }
    }
}
