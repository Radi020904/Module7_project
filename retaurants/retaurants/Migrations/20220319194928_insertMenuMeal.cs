using Microsoft.EntityFrameworkCore.Migrations;

namespace restaurants.Migrations
{
    public partial class insertMenuMeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuMeals",
                columns: new[] { "MenuId", "MealId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 4, 19 },
                    { 4, 18 },
                    { 4, 17 },
                    { 3, 16 },
                    { 3, 15 },
                    { 3, 14 },
                    { 3, 13 },
                    { 3, 12 },
                    { 2, 11 },
                    { 2, 10 },
                    { 2, 9 },
                    { 2, 8 },
                    { 2, 7 },
                    { 1, 6 },
                    { 1, 5 },
                    { 1, 4 },
                    { 1, 3 },
                    { 4, 20 },
                    { 4, 21 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 3, 14 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 3, 16 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 4, 18 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 4, 19 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 4, 20 });

            migrationBuilder.DeleteData(
                table: "MenuMeals",
                keyColumns: new[] { "MenuId", "MealId" },
                keyValues: new object[] { 4, 21 });
        }
    }
}
