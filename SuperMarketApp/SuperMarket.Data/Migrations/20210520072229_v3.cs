using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarket.Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stafs_addresses_addressId",
                table: "stafs");

            migrationBuilder.DropForeignKey(
                name: "FK_stafs_roles_roleId",
                table: "stafs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stafs",
                table: "stafs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.RenameTable(
                name: "stafs",
                newName: "Staff");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "addresses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Staff",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_stafs_roleId",
                table: "Staff",
                newName: "IX_Staff_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_stafs_addressId",
                table: "Staff",
                newName: "IX_Staff_addressId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "staffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "addressId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Address_addressId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Role_RoleId",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "stafs");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "addresses");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "stafs",
                newName: "roleId");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_RoleId",
                table: "stafs",
                newName: "IX_stafs_roleId");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_addressId",
                table: "stafs",
                newName: "IX_stafs_addressId");

            migrationBuilder.AlterColumn<int>(
                name: "addressId",
                table: "stafs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "roleId",
                table: "stafs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_stafs",
                table: "stafs",
                column: "staffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "addressId");

            migrationBuilder.AddForeignKey(
                name: "FK_stafs_addresses_addressId",
                table: "stafs",
                column: "addressId",
                principalTable: "addresses",
                principalColumn: "addressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stafs_roles_roleId",
                table: "stafs",
                column: "roleId",
                principalTable: "roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
