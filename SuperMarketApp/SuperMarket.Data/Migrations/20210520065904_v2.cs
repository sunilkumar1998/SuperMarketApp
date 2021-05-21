using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarket.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stafs_addresses_address_Id",
                table: "stafs");

            migrationBuilder.DropForeignKey(
                name: "FK_stafs_roles_role_Id",
                table: "stafs");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "stafs");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "stafs");

            migrationBuilder.DropColumn(
                name: "addressLine_1",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "addressLine_2",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "pin_code",
                table: "addresses");

            migrationBuilder.RenameColumn(
                name: "role_Id",
                table: "stafs",
                newName: "roleId");

            migrationBuilder.RenameColumn(
                name: "address_Id",
                table: "stafs",
                newName: "addressId");

            migrationBuilder.RenameColumn(
                name: "staff_Id",
                table: "stafs",
                newName: "staffId");

            migrationBuilder.RenameIndex(
                name: "IX_stafs_role_Id",
                table: "stafs",
                newName: "IX_stafs_roleId");

            migrationBuilder.RenameIndex(
                name: "IX_stafs_address_Id",
                table: "stafs",
                newName: "IX_stafs_addressId");

            migrationBuilder.RenameColumn(
                name: "Role_Id",
                table: "roles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "address_Id",
                table: "addresses",
                newName: "addressId");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "stafs",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "stafs",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "stafs",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "roles",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "roles",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "state",
                table: "addresses",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "addresses",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "addressLine1",
                table: "addresses",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "addressLine2",
                table: "addresses",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "pincode",
                table: "addresses",
                type: "bigint",
                maxLength: 6,
                nullable: false,
                defaultValue: 0L);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stafs_addresses_addressId",
                table: "stafs");

            migrationBuilder.DropForeignKey(
                name: "FK_stafs_roles_roleId",
                table: "stafs");

            migrationBuilder.DropColumn(
                name: "firstname",
                table: "stafs");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "stafs");

            migrationBuilder.DropColumn(
                name: "addressLine1",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "addressLine2",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "pincode",
                table: "addresses");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "stafs",
                newName: "role_Id");

            migrationBuilder.RenameColumn(
                name: "addressId",
                table: "stafs",
                newName: "address_Id");

            migrationBuilder.RenameColumn(
                name: "staffId",
                table: "stafs",
                newName: "staff_Id");

            migrationBuilder.RenameIndex(
                name: "IX_stafs_roleId",
                table: "stafs",
                newName: "IX_stafs_role_Id");

            migrationBuilder.RenameIndex(
                name: "IX_stafs_addressId",
                table: "stafs",
                newName: "IX_stafs_address_Id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "roles",
                newName: "Role_Id");

            migrationBuilder.RenameColumn(
                name: "addressId",
                table: "addresses",
                newName: "address_Id");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "stafs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "stafs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "stafs",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "roles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "roles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "state",
                table: "addresses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "addresses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "addressLine_1",
                table: "addresses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "addressLine_2",
                table: "addresses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "pin_code",
                table: "addresses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_stafs_addresses_address_Id",
                table: "stafs",
                column: "address_Id",
                principalTable: "addresses",
                principalColumn: "address_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stafs_roles_role_Id",
                table: "stafs",
                column: "role_Id",
                principalTable: "roles",
                principalColumn: "Role_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
