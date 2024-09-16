using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oleksandr_Lut_zal.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_owner_id_to_positions_list : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ownerId",
                table: "ShoppingPositionList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ownerId",
                table: "ShopingPositions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShopingPositions_ShoopingListId",
                table: "ShopingPositions",
                column: "ShoopingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingPositions_ShoppingPositionList_ShoopingListId",
                table: "ShopingPositions",
                column: "ShoopingListId",
                principalTable: "ShoppingPositionList",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingPositions_ShoppingPositionList_ShoopingListId",
                table: "ShopingPositions");

            migrationBuilder.DropIndex(
                name: "IX_ShopingPositions_ShoopingListId",
                table: "ShopingPositions");

            migrationBuilder.DropColumn(
                name: "ownerId",
                table: "ShoppingPositionList");

            migrationBuilder.DropColumn(
                name: "ownerId",
                table: "ShopingPositions");
        }
    }
}
