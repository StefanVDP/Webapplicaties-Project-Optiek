using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Optiek.Data.Migrations
{
    public partial class AdminAanmaken1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Gebruikers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_UserID",
                table: "Gebruikers",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_AspNetUsers_UserID",
                table: "Gebruikers",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_AspNetUsers_UserID",
                table: "Gebruikers");

            migrationBuilder.DropIndex(
                name: "IX_Gebruikers_UserID",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
