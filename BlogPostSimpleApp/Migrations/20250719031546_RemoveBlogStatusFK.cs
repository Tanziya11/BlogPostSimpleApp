using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPostSimpleApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBlogStatusFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Status_StatusId",
                table: "Blogs");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Blogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Status_StatusId",
                table: "Blogs",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Status_StatusId",
                table: "Blogs");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Status_StatusId",
                table: "Blogs",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
