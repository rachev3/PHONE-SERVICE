using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHONE_SERVICE.Migrations
{
    public partial class OneToManyTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairRequests_AspNetUsers_WorkerUserId",
                table: "RepairRequests");

            migrationBuilder.DropIndex(
                name: "IX_RepairRequests_ClientUserId",
                table: "RepairRequests");

            migrationBuilder.CreateIndex(
                name: "IX_RepairRequests_ClientUserId",
                table: "RepairRequests",
                column: "ClientUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairRequests_AspNetUsers_WorkerUserId",
                table: "RepairRequests",
                column: "WorkerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairRequests_AspNetUsers_WorkerUserId",
                table: "RepairRequests");

            migrationBuilder.DropIndex(
                name: "IX_RepairRequests_ClientUserId",
                table: "RepairRequests");

            migrationBuilder.CreateIndex(
                name: "IX_RepairRequests_ClientUserId",
                table: "RepairRequests",
                column: "ClientUserId",
                unique: true,
                filter: "[ClientUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairRequests_AspNetUsers_WorkerUserId",
                table: "RepairRequests",
                column: "WorkerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
