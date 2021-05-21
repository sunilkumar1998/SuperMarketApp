using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarket.Data.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Address_addressId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Role_RoleId",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Staff",
                newName: "roleId");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_RoleId",
                table: "Staff",
                newName: "IX_Staff_roleId");

            migrationBuilder.AlterColumn<int>(
                name: "addressId",
                table: "Staff",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "roleId",
                table: "Staff",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Address_addressId",
                table: "Staff",
                column: "addressId",
                principalTable: "Address",
                principalColumn: "addressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Role_roleId",
                table: "Staff",
                column: "roleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Address_addressId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Role_roleId",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Staff",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_roleId",
                table: "Staff",
                newName: "IX_Staff_RoleId");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Staff",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "addressId",
                table: "Staff",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Address_addressId",
                table: "Staff",
                column: "addressId",
                principalTable: "Address",
                principalColumn: "addressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Role_RoleId",
                table: "Staff",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
