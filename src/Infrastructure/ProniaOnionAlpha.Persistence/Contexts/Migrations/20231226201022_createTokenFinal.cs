using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProniaOnionAlpha.Persistence.Contexts.Migrations
{
    public partial class createTokenFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Authors");
        }
    }
}
