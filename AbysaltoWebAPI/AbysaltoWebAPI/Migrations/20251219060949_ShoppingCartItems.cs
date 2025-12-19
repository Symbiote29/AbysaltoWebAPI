using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbysaltoWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    cartId = table.Column<Guid>(type: "uuid", nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.cartId);
                });

            migrationBuilder.CreateTable(
                name: "cartItems",
                columns: table => new
                {
                    itemId = table.Column<Guid>(type: "uuid", nullable: false),
                    cartId = table.Column<Guid>(type: "uuid", nullable: false),
                    productId = table.Column<int>(type: "integer", nullable: false),
                    productName = table.Column<string>(type: "text", nullable: false),
                    itemPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItems", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_cartItems_carts_cartId",
                        column: x => x.cartId,
                        principalTable: "carts",
                        principalColumn: "cartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_cartId",
                table: "cartItems",
                column: "cartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartItems");

            migrationBuilder.DropTable(
                name: "carts");
        }
    }
}
