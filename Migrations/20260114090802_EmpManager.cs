using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecBatch2025MVCCoreProject.Migrations
{
    /// <inheritdoc />
    public partial class EmpManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mang",
                columns: table => new
                {
                    mid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mang", x => x.mid);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    eid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    esalary = table.Column<double>(type: "float", nullable: false),
                    mid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.eid);
                    table.ForeignKey(
                        name: "FK_employees_mang_mid",
                        column: x => x.mid,
                        principalTable: "mang",
                        principalColumn: "mid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_mid",
                table: "employees",
                column: "mid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "mang");
        }
    }
}
