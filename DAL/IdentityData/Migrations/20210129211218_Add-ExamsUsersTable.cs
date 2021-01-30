using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.IdentityData.Migrations
{
    public partial class AddExamsUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Exams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ExamsUsers",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamsUsers", x => new { x.ExamId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ExamsUsers_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamsUsers_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_TeacherId",
                table: "Exams",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamsUsers_StudentId",
                table: "ExamsUsers",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_TeacherId",
                table: "Exams",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_TeacherId",
                table: "Exams");

            migrationBuilder.DropTable(
                name: "ExamsUsers");

            migrationBuilder.DropIndex(
                name: "IX_Exams_TeacherId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
