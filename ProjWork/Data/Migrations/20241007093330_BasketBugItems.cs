using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjWork.Migrations
{
    /// <inheritdoc />
    public partial class BasketBugItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_CustomersBaskets_CustomersBasketId",
                table: "BasketItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItem",
                table: "BasketItem");

            migrationBuilder.RenameTable(
                name: "BasketItem",
                newName: "BasketItems");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_CustomersBasketId",
                table: "BasketItems",
                newName: "IX_BasketItems_CustomersBasketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_CustomersBaskets_CustomersBasketId",
                table: "BasketItems",
                column: "CustomersBasketId",
                principalTable: "CustomersBaskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_CustomersBaskets_CustomersBasketId",
                table: "BasketItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketItems",
                table: "BasketItems");

            migrationBuilder.RenameTable(
                name: "BasketItems",
                newName: "BasketItem");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItems_CustomersBasketId",
                table: "BasketItem",
                newName: "IX_BasketItem_CustomersBasketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketItem",
                table: "BasketItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_CustomersBaskets_CustomersBasketId",
                table: "BasketItem",
                column: "CustomersBasketId",
                principalTable: "CustomersBaskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
