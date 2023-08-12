using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class AddrequestIdMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Request_RequestId",
                table: "Material");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "Material",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Request_RequestId",
                table: "Material",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Request_RequestId",
                table: "Material");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "Material",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Request_RequestId",
                table: "Material",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id");
        }
    }
}
