using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_UserId",
                table: "Abouts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_AspNetUsers_UserId",
                table: "Abouts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_AspNetUsers_UserId",
                table: "Abouts");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_UserId",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Abouts");
        }
    }
}
