using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2BSalonAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_BusinessTypes_BusinessTypeId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_BusinessTypeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BusinessTypeId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BusinessTypeId",
                table: "Categories",
                column: "BusinessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_BusinessTypes_BusinessTypeId",
                table: "Categories",
                column: "BusinessTypeId",
                principalTable: "BusinessTypes",
                principalColumn: "BusinessTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
