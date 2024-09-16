using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oleksandr_Lut_zal.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_shoping_position_and_add_shoping_list : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoopingListId",
                table: "ShopingPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingPositionListid",
                table: "ShopingPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShoppingPositionList",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    listTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingPositionList", x => x.id);
                });

            migrationBuilder.InsertData(
            table: "ShoppingPositionList",
            columns: new[] { "id", "listTitle" },
            values: new object[] { 1, "Lista zbiorcza" });

            migrationBuilder.Sql("UPDATE ShopingPositions SET ShoppingPositionListid = 1 WHERE ShoppingPositionListid = 0");


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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingPositions_ShoppingPositionList_ShoppingPositionListid",
                table: "ShopingPositions");

            migrationBuilder.DropTable(
                name: "ShoppingPositionList");

            migrationBuilder.DropIndex(
                name: "IX_ShopingPositions_ShoppingPositionListid",
                table: "ShopingPositions");

            migrationBuilder.DropColumn(
                name: "ShoopingListId",
                table: "ShopingPositions");

            migrationBuilder.DropColumn(
                name: "ShoppingPositionListid",
                table: "ShopingPositions");
        }
    }
}
