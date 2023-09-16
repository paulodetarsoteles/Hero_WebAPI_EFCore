using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hero_WebAPI_EFCore.Web.Migrations
{
    /// <inheritdoc />
    public partial class Update_Models_and_Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Secrets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HeroesMovies",
                columns: table => new
                {
                    HeroId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroesMovies", x => new { x.HeroId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_HeroesMovies_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "HeroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroesMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_HeroId",
                table: "Weapons",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Secrets_HeroId",
                table: "Secrets",
                column: "HeroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeroesMovies_MovieId",
                table: "HeroesMovies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Secrets_Heroes_HeroId",
                table: "Secrets",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Secrets_Heroes_HeroId",
                table: "Secrets");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons");

            migrationBuilder.DropTable(
                name: "HeroesMovies");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_HeroId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Secrets_HeroId",
                table: "Secrets");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Secrets");
        }
    }
}
