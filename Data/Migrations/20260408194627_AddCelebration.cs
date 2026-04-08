using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCircle.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCelebration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celebrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeveloperInitials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celebrations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Celebrations");
        }
    }
}
