using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoMusicaArtista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "artistaId",
                table: "Musica",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musica_artistaId",
                table: "Musica",
                column: "artistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musica_Artistas_artistaId",
                table: "Musica",
                column: "artistaId",
                principalTable: "Artistas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musica_Artistas_artistaId",
                table: "Musica");

            migrationBuilder.DropIndex(
                name: "IX_Musica_artistaId",
                table: "Musica");

            migrationBuilder.DropColumn(
                name: "artistaId",
                table: "Musica");
        }
    }
}
