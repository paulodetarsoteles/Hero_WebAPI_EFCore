using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hero_WebAPI_EFCore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Secret_HeroId_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Secrets_Heroes_HeroId",
                table: "Secrets");

            migrationBuilder.AlterColumn<int>(
                name: "HeroId",
                table: "Secrets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Secrets_Heroes_HeroId",
                table: "Secrets",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "HeroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Secrets_Heroes_HeroId",
                table: "Secrets");

            migrationBuilder.AlterColumn<int>(
                name: "HeroId",
                table: "Secrets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Secrets_Heroes_HeroId",
                table: "Secrets",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
