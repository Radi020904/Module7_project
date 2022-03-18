using Microsoft.EntityFrameworkCore.Migrations;

namespace restaurants.Migrations
{
    public partial class int3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<double>(nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    Language = table.Column<string>(maxLength: 50, nullable: false),
                    Link = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuMeal",
                columns: table => new
                {
                    MealId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMeal", x => new { x.MenuId, x.MealId });
                    table.ForeignKey(
                        name: "FK_MenuMeal_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuMeal_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuMeal_MealId",
                table: "MenuMeal",
                column: "MealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuMeal");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
