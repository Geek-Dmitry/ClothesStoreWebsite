using Microsoft.EntityFrameworkCore.Migrations;

namespace ClothesStoreWebsite.Migrations
{
    public partial class AddedUserWishList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "WishProductForId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_WishProductForId",
                table: "Products",
                column: "WishProductForId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_WishProductForId",
                table: "Products",
                column: "WishProductForId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_WishProductForId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_WishProductForId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WishProductForId",
                table: "Products");
        }
    }
}
