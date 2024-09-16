using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oleksandr_Lut_zal.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_shopping_position_list_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingPositions_ShoppingPositionList_ShoppingPositionListid",
                table: "ShopingPositions");

            migrationBuilder.DropIndex(
                name: "IX_ShopingPositions_ShoppingPositionListid",
                table: "ShopingPositions");

            migrationBuilder.DropColumn(
                name: "ShoppingPositionListid",
                table: "ShopingPositions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingPositionListid",
                table: "ShopingPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopingPositions_ShoppingPositionListid",
                table: "ShopingPositions",
                column: "ShoppingPositionListid");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingPositions_ShoppingPositionList_ShoppingPositionListid",
                table: "ShopingPositions",
                column: "ShoppingPositionListid",
                principalTable: "ShoppingPositionList",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
