using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjWork.Migrations
{
    /// <inheritdoc />
    public partial class forthMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_CustomersBaskets_CustomersBasketId",
                table: "BasketItem");

            migrationBuilder.AlterColumn<string>(
                name: "CustomersBasketId",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_CustomersBaskets_CustomersBasketId",
                table: "BasketItem",
                column: "CustomersBasketId",
                principalTable: "CustomersBaskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_CustomersBaskets_CustomersBasketId",
                table: "BasketItem");

            migrationBuilder.AlterColumn<string>(
                name: "CustomersBasketId",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_CustomersBaskets_CustomersBasketId",
                table: "BasketItem",
                column: "CustomersBasketId",
                principalTable: "CustomersBaskets",
                principalColumn: "Id");
        }
    }
}
