using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class AddGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musica_Artistas_artistaId",
                table: "Musica");

            migrationBuilder.AlterColumn<int>(
                name: "artistaId",
                table: "Musica",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnoLancamento",
                table: "Musica",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Musica_Artistas_artistaId",
                table: "Musica",
                column: "artistaId",
                principalTable: "Artistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musica_Artistas_artistaId",
                table: "Musica");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.AlterColumn<int>(
                name: "artistaId",
                table: "Musica",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnoLancamento",
                table: "Musica",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Musica_Artistas_artistaId",
                table: "Musica",
                column: "artistaId",
                principalTable: "Artistas",
                principalColumn: "Id");
        }
    }
}
