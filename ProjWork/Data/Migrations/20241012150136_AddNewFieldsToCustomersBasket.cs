using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjWork.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToCustomersBasket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientSecret",
                table: "CustomersBaskets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryMethodId",
                table: "CustomersBaskets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "CustomersBaskets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientSecret",
                table: "CustomersBaskets");

            migrationBuilder.DropColumn(
                name: "DeliveryMethodId",
                table: "CustomersBaskets");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "CustomersBaskets");
        }
    }
}
