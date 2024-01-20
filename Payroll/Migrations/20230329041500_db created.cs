using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payroll.Migrations
{
    /// <inheritdoc />
    public partial class dbcreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryClass",
                columns: table => new
                {
                    ClassName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BasicPay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TraverAllowance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalAlowance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternetAllowance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryClass", x => x.ClassName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryClass");
        }
    }
}
