using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPostSimpleApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogType_BlogTypeId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Status_StatusId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_StatusId",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogType",
                table: "BlogType");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "BlogType",
                newName: "BlogTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BlogTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BlogTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogTypes",
                table: "BlogTypes",
                column: "BlogTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogTypes_BlogTypeId",
                table: "Blogs",
                column: "BlogTypeId",
                principalTable: "BlogTypes",
                principalColumn: "BlogTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogTypes_BlogTypeId",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogTypes",
                table: "BlogTypes");

            migrationBuilder.RenameTable(
                name: "BlogTypes",
                newName: "BlogType");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BlogType",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BlogType",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogType",
                table: "BlogType",
                column: "BlogTypeId");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_StatusId",
                table: "Blogs",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogType_BlogTypeId",
                table: "Blogs",
                column: "BlogTypeId",
                principalTable: "BlogType",
                principalColumn: "BlogTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Status_StatusId",
                table: "Blogs",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId");
        }
    }
}
