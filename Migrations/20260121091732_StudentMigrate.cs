using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecBatch2025MVCCoreProject.Migrations
{
    /// <inheritdoc />
    public partial class StudentMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stud",
                columns: table => new
                {
                    sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scourse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sprofile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stud", x => x.sid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stud");
        }
    }
}
