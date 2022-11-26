using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Agency_AgencyId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "AgencyCustomer");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.RenameColumn(
                name: "AgencyId",
                table: "Customers",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_AgencyId",
                table: "Customers",
                newName: "IX_Customers_EmployeeId");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Employee_EmployeeId",
                table: "Customers",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Employee_EmployeeId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Customers",
                newName: "AgencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_EmployeeId",
                table: "Customers",
                newName: "IX_Customers_AgencyId");

            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgencyCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AgencyID = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyCustomer_Agency_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgencyCustomer_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgencyCustomer_AgencyID",
                table: "AgencyCustomer",
                column: "AgencyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgencyCustomer_CustomerID",
                table: "AgencyCustomer",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Agency_AgencyId",
                table: "Customers",
                column: "AgencyId",
                principalTable: "Agency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
