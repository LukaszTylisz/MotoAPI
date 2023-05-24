using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoAPI.Migrations
{
    /// <inheritdoc />
    public partial class MotoUserIdAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Motos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motos_CreatedById",
                table: "Motos",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Users_CreatedById",
                table: "Motos",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Users_CreatedById",
                table: "Motos");

            migrationBuilder.DropIndex(
                name: "IX_Motos_CreatedById",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Motos");
        }
    }
}
