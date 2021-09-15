using Microsoft.EntityFrameworkCore.Migrations;

namespace BloggerAPI.Migrations
{
    public partial class userIdforginkeymarked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "BlogPosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_userId",
                table: "BlogPosts",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Users_userId",
                table: "BlogPosts",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Users_userId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_userId",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
