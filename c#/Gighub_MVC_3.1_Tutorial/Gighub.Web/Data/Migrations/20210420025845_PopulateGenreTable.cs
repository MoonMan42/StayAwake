using Microsoft.EntityFrameworkCore.Migrations;

namespace Gighub.Web.Data.Migrations
{
    public partial class PopulateGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Genres", "Name", "Jazz");
            migrationBuilder.InsertData("Genres", "Name", "Blues");
            migrationBuilder.InsertData("Genres", "Name", "R&B");
            migrationBuilder.InsertData("Genres", "Name", "Rock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
