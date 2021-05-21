using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarket.Data.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Supplier",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "Supplier",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "email",
                table: "Supplier",
                type: "double precision",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<double>(
                name: "city",
                table: "Supplier",
                type: "double precision",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }
    }
}
