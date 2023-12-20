using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHONE_SERVICE.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_PhoneModels_PhoneModelId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_PhoneModelId",
                table: "Repairs");

            migrationBuilder.CreateTable(
                name: "PhoneModelRepair",
                columns: table => new
                {
                    PhoneModelId = table.Column<int>(type: "int", nullable: false),
                    RepairsRepairId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneModelRepair", x => new { x.PhoneModelId, x.RepairsRepairId });
                    table.ForeignKey(
                        name: "FK_PhoneModelRepair_PhoneModels_PhoneModelId",
                        column: x => x.PhoneModelId,
                        principalTable: "PhoneModels",
                        principalColumn: "PhoneModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneModelRepair_Repairs_RepairsRepairId",
                        column: x => x.RepairsRepairId,
                        principalTable: "Repairs",
                        principalColumn: "RepairId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairPhoneModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairId = table.Column<int>(type: "int", nullable: false),
                    PhoneModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairPhoneModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModelRepair_RepairsRepairId",
                table: "PhoneModelRepair",
                column: "RepairsRepairId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneModelRepair");

            migrationBuilder.DropTable(
                name: "RepairPhoneModels");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_PhoneModelId",
                table: "Repairs",
                column: "PhoneModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_PhoneModels_PhoneModelId",
                table: "Repairs",
                column: "PhoneModelId",
                principalTable: "PhoneModels",
                principalColumn: "PhoneModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
