using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UnitOfWorkDesignPattern.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class bank_Application : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CustomerBalance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    ProcessID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sender = table.Column<int>(type: "integer", nullable: false),
                    Receiver = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.ProcessID);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "CustomerBalance", "CustomerName" },
                values: new object[,]
                {
                    { 1, 1000m, "Murat" },
                    { 2, 2000m, "Numan" },
                    { 3, 1500m, "Ayşe" },
                    { 4, 2500m, "Kadir" },
                    { 5, 3000m, "Fatma" }
                });

            migrationBuilder.InsertData(
                table: "Processes",
                columns: new[] { "ProcessID", "Amount", "Receiver", "Sender" },
                values: new object[,]
                {
                    { 1, 500m, 2, 1 },
                    { 2, 700m, 3, 2 },
                    { 3, 600m, 4, 3 },
                    { 4, 900m, 5, 4 },
                    { 5, 1200m, 1, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Processes");
        }
    }
}
