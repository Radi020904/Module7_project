using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace restaurants.Migrations
{
    public partial class insertRestaurantAndCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Capacity", "Link", "Location", "MenuId", "Name" },
                values: new object[,]
                {
                    { 1, 50, "https://martisbakery/PinchOfSalt.com", "Haskovo", 1, "PinchOfSalt" },
                    { 2, 40, "https://atasmcdonalds/HaskovoMcDonald.com", "Haskovo", 2, "HaskovoMcDonald" },
                    { 3, 200, "https://radisbar/Sense.com", "Barcelona", 3, "Sense" },
                    { 4, 30, "https://ganisdoner/HisarDoner.com", "Istanbul", 4, "HisarDoner" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreationDate", "Name", "OwnerName", "RestaurantId" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "martisbakery", "Marti", 1 },
                    { 2, new DateTime(2009, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "atasmcdonalds", "Ata", 2 },
                    { 3, new DateTime(2004, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "radisbar", "Radi", 3 },
                    { 4, new DateTime(2003, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "ganisdoner", "Gani", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
