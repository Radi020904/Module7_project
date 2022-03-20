using Microsoft.EntityFrameworkCore.Migrations;

namespace restaurants.Migrations
{
    public partial class insertStaffRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StaffRestaurants",
                columns: new[] { "RestaurantId", "StaffId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 4, 7 },
                    { 4, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StaffRestaurants",
                keyColumns: new[] { "RestaurantId", "StaffId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StaffRestaurants",
                keyColumns: new[] { "RestaurantId", "StaffId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "StaffRestaurants",
                keyColumns: new[] { "RestaurantId", "StaffId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "StaffRestaurants",
                keyColumns: new[] { "RestaurantId", "StaffId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "StaffRestaurants",
                keyColumns: new[] { "RestaurantId", "StaffId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "StaffRestaurants",
                keyColumns: new[] { "RestaurantId", "StaffId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "StaffRestaurants",
                keyColumns: new[] { "RestaurantId", "StaffId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "StaffRestaurants",
                keyColumns: new[] { "RestaurantId", "StaffId" },
                keyValues: new object[] { 4, 8 });
        }
    }
}
