using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsStore.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Line1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Line2",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Line3",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Orders",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Orders",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "Line1",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Line2",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Line3",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
