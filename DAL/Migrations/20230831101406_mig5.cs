using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Albums_Photo",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_Photo",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Albums");

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AlbumId",
                table: "Photos",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Albums_AlbumId",
                table: "Photos",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Albums_AlbumId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_AlbumId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Photos");

            migrationBuilder.AddColumn<int>(
                name: "Photo",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Albums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_Photo",
                table: "Photos",
                column: "Photo");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Albums_Photo",
                table: "Photos",
                column: "Photo",
                principalTable: "Albums",
                principalColumn: "AlbumId");
        }
    }
}
