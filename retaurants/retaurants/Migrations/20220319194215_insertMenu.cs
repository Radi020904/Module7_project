using Microsoft.EntityFrameworkCore.Migrations;

namespace restaurants.Migrations
{
    public partial class insertMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Language", "Link", "Rating", "Type" },
                values: new object[,]
                {
                    { 1, "bulgarian", "https://martisbakery/PinchOfSalt/menu.com", 9.0, "Dessert" },
                    { 2, "english", "https://atasmcdonalds/HaskovoMcDonald/menu.com", 8.0, "Fast Food" },
                    { 3, "spanish", "https://radisbar/Sense/menu.com", 8.4000000000000004, "Cocktail" },
                    { 4, "turkish", "https://ganisdoner/HisarDoner/menu.com", 9.5, "Fast Food" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
