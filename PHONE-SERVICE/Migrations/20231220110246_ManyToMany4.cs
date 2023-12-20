using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHONE_SERVICE.Migrations
{
    public partial class ManyToMany4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneModelRepair");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModelsRepair_PhoneModelId",
                table: "PhoneModelsRepair",
                column: "PhoneModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModelsRepair_RepairId",
                table: "PhoneModelsRepair",
                column: "RepairId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneModelsRepair_PhoneModels_PhoneModelId",
                table: "PhoneModelsRepair",
                column: "PhoneModelId",
                principalTable: "PhoneModels",
                principalColumn: "PhoneModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneModelsRepair_Repairs_RepairId",
                table: "PhoneModelsRepair",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "RepairId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneModelsRepair_PhoneModels_PhoneModelId",
                table: "PhoneModelsRepair");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneModelsRepair_Repairs_RepairId",
                table: "PhoneModelsRepair");

            migrationBuilder.DropIndex(
                name: "IX_PhoneModelsRepair_PhoneModelId",
                table: "PhoneModelsRepair");

            migrationBuilder.DropIndex(
                name: "IX_PhoneModelsRepair_RepairId",
                table: "PhoneModelsRepair");

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

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModelRepair_RepairsRepairId",
                table: "PhoneModelRepair",
                column: "RepairsRepairId");
        }
    }
}
