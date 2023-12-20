using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHONE_SERVICE.Migrations
{
    public partial class ManyToMany3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneModelId",
                table: "Repairs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhoneModelId",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
