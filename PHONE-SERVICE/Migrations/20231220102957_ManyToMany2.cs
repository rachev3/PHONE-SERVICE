using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHONE_SERVICE.Migrations
{
    public partial class ManyToMany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairPhoneModels");

            migrationBuilder.CreateTable(
                name: "PhoneModelsRepair",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneModelId = table.Column<int>(type: "int", nullable: false),
                    RepairId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneModelsRepair", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneModelsRepair");

            migrationBuilder.CreateTable(
                name: "RepairPhoneModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneModelId = table.Column<int>(type: "int", nullable: false),
                    RepairId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairPhoneModels", x => x.Id);
                });
        }
    }
}
