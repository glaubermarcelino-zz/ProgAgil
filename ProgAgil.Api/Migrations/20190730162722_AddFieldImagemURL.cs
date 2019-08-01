using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgAgil.Api.Migrations
{
    public partial class AddFieldImagemURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemURL",
                table: "Eventos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemURL",
                table: "Eventos");
        }
    }
}
