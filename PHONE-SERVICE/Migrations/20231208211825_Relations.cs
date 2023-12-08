using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHONE_SERVICE.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairRequests_AspNetUsers_UserId",
                table: "RepairRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_AspNetUsers_UserId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_UserId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Repairs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RepairRequests",
                newName: "WorkerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_RepairRequests_UserId",
                table: "RepairRequests",
                newName: "IX_RepairRequests_WorkerUserId");

            migrationBuilder.AddColumn<string>(
                name: "ClientUserId",
                table: "RepairRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairRequests_ClientUserId",
                table: "RepairRequests",
                column: "ClientUserId",
                unique: true,
                filter: "[ClientUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairRequests_AspNetUsers_ClientUserId",
                table: "RepairRequests",
                column: "ClientUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairRequests_AspNetUsers_WorkerUserId",
                table: "RepairRequests",
                column: "WorkerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairRequests_AspNetUsers_ClientUserId",
                table: "RepairRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairRequests_AspNetUsers_WorkerUserId",
                table: "RepairRequests");

            migrationBuilder.DropIndex(
                name: "IX_RepairRequests_ClientUserId",
                table: "RepairRequests");

            migrationBuilder.DropColumn(
                name: "ClientUserId",
                table: "RepairRequests");

            migrationBuilder.RenameColumn(
                name: "WorkerUserId",
                table: "RepairRequests",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RepairRequests_WorkerUserId",
                table: "RepairRequests",
                newName: "IX_RepairRequests_UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Repairs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_UserId",
                table: "Repairs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairRequests_AspNetUsers_UserId",
                table: "RepairRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_AspNetUsers_UserId",
                table: "Repairs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
