using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oleksandr_Lut_zal.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_list_planned_date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PlannedDate",
                table: "ShoppingPositionList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlannedDate",
                table: "ShoppingPositionList");
        }
    }
}
