using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class AddListRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Material_RequestMaterialId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_RequestMaterialId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "RequestMaterialId",
                table: "Request");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Material",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_RequestId",
                table: "Material",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Request_RequestId",
                table: "Material",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Request_RequestId",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Material_RequestId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Material");

            migrationBuilder.AddColumn<int>(
                name: "RequestMaterialId",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestMaterialId",
                table: "Request",
                column: "RequestMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Material_RequestMaterialId",
                table: "Request",
                column: "RequestMaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
