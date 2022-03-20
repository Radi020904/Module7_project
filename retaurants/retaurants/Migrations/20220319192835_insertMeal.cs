using Microsoft.EntityFrameworkCore.Migrations;

namespace restaurants.Migrations
{
    public partial class insertMeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Name", "PortionSize", "Price", "Type" },
                values: new object[,]
                {
                    { 1, " Black Forest Gateau", 150.0, 5.5, "Cake" },
                    { 19, "Tabak Doner", 420.0, 6.0, "Doner" },
                    { 18, "Ekmek Doner", 340.0, 5.0999999999999996, "Doner" },
                    { 17, "Durum Doner", 300.0, 4.2999999999999998, "Doner" },
                    { 16, "Sex On The Beach", 110.0, 12.0, "Cocktail" },
                    { 15, "Gin Tonic", 95.0, 11.0, "Cocktail" },
                    { 14, "Cuba Libre", 80.0, 10.0, "Cocktail" },
                    { 13, "Martini", 90.0, 12.0, "Cocktail" },
                    { 12, "Mojito", 100.0, 10.0, "Cocktail" },
                    { 11, "McNuggets", 400.0, 8.0, "nuggets" },
                    { 10, "CheeseBurger", 500.0, 9.0, "Burger" },
                    { 9, "BigMac", 600.0, 10.4, "Burger" },
                    { 8, "McSpicy", 450.0, 8.0999999999999996, "Burger" },
                    { 7, "McChicken", 400.0, 8.0, "Burger" },
                    { 6, "Chocolate Whip", 300.0, 4.0999999999999996, "Chocolates" },
                    { 5, "Brown Bread", 200.0, 4.4000000000000004, "Icecream" },
                    { 4, "Blue Heaven", 100.0, 3.1000000000000001, "Icecream" },
                    { 3, "Beer Ice Cream", 150.0, 3.3999999999999999, "Icecream" },
                    { 20, "Iskender Doner", 380.0, 6.0, "Doner" },
                    { 21, "Lahmacun", 210.0, 3.5, "pide" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
