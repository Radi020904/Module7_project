using Microsoft.EntityFrameworkCore.Migrations;

namespace restaurants.Migrations
{
    public partial class insertStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Age", "FirstName", "Job", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, 28.0, "Samuel", "Chef", "Umtiti", 900.0 },
                    { 2, 30.0, "Martin", "Waiter", "Braithwaite", 600.0 },
                    { 3, 23.0, "Kylian", "Chef", "Mbappe", 1000.0 },
                    { 4, 21.0, "Erling", "Waiter", "Halland", 800.0 },
                    { 5, 34.0, "Lionel", "Bartender", "Messi", 1100.0 },
                    { 6, 35.0, "Luis", "Waiter", "Suarez", 800.0 },
                    { 7, 35.0, "Sergio", "Dunerman", "Ramos", 1000.0 },
                    { 8, 30.0, "Carlos", "Waiter", "Casemiro", 700.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
