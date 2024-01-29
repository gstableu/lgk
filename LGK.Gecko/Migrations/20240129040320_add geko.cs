using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LGK.Geckos.Migrations
{
    /// <inheritdoc />
    public partial class addgeko : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gecko",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SireId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfIncubation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gecko", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Morphs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Morphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Morphs_Gecko_LPId",
                        column: x => x.LPId,
                        principalTable: "Gecko",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Morphs_LPId",
                table: "Morphs",
                column: "LPId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Morphs");

            migrationBuilder.DropTable(
                name: "Gecko");
        }
    }
}
