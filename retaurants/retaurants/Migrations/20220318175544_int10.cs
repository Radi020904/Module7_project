using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace restaurants.Migrations
{
    public partial class int10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMeal_Meals_MealId",
                table: "MenuMeal");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMeal_Menu_MenuId",
                table: "MenuMeal");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Menu_MenuId",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRestaurant_Restaurant_RestaurantId",
                table: "StaffRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRestaurant_Staff_StaffId",
                table: "StaffRestaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffRestaurant",
                table: "StaffRestaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuMeal",
                table: "MenuMeal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meals",
                table: "Meals");

            migrationBuilder.RenameTable(
                name: "StaffRestaurant",
                newName: "StaffRestaurants");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "Staffs");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                newName: "Restaurants");

            migrationBuilder.RenameTable(
                name: "MenuMeal",
                newName: "MenuMeals");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameTable(
                name: "Meals",
                newName: "Meal");

            migrationBuilder.RenameIndex(
                name: "IX_StaffRestaurant_StaffId",
                table: "StaffRestaurants",
                newName: "IX_StaffRestaurants_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_MenuId",
                table: "Restaurants",
                newName: "IX_Restaurants_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuMeal_MealId",
                table: "MenuMeals",
                newName: "IX_MenuMeals_MealId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffRestaurants",
                table: "StaffRestaurants",
                columns: new[] { "RestaurantId", "StaffId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuMeals",
                table: "MenuMeals",
                columns: new[] { "MenuId", "MealId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OwnerName = table.Column<string>(maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RestaurantId",
                table: "Companies",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMeals_Meal_MealId",
                table: "MenuMeals",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMeals_Menus_MenuId",
                table: "MenuMeals",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Menus_MenuId",
                table: "Restaurants",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRestaurants_Restaurants_RestaurantId",
                table: "StaffRestaurants",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRestaurants_Staffs_StaffId",
                table: "StaffRestaurants",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMeals_Meal_MealId",
                table: "MenuMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMeals_Menus_MenuId",
                table: "MenuMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Menus_MenuId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRestaurants_Restaurants_RestaurantId",
                table: "StaffRestaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffRestaurants_Staffs_StaffId",
                table: "StaffRestaurants");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffRestaurants",
                table: "StaffRestaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuMeals",
                table: "MenuMeals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.RenameTable(
                name: "Staffs",
                newName: "Staff");

            migrationBuilder.RenameTable(
                name: "StaffRestaurants",
                newName: "StaffRestaurant");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Restaurant");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameTable(
                name: "MenuMeals",
                newName: "MenuMeal");

            migrationBuilder.RenameTable(
                name: "Meal",
                newName: "Meals");

            migrationBuilder.RenameIndex(
                name: "IX_StaffRestaurants_StaffId",
                table: "StaffRestaurant",
                newName: "IX_StaffRestaurant_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_MenuId",
                table: "Restaurant",
                newName: "IX_Restaurant_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuMeals_MealId",
                table: "MenuMeal",
                newName: "IX_MenuMeal_MealId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffRestaurant",
                table: "StaffRestaurant",
                columns: new[] { "RestaurantId", "StaffId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuMeal",
                table: "MenuMeal",
                columns: new[] { "MenuId", "MealId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meals",
                table: "Meals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMeal_Meals_MealId",
                table: "MenuMeal",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMeal_Menu_MenuId",
                table: "MenuMeal",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Menu_MenuId",
                table: "Restaurant",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRestaurant_Restaurant_RestaurantId",
                table: "StaffRestaurant",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffRestaurant_Staff_StaffId",
                table: "StaffRestaurant",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
