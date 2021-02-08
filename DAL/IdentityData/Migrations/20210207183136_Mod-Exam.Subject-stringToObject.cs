using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.IdentityData.Migrations
{
    public partial class ModExamSubjectstringToObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Subjects_SubjectObjId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "SubjectObjId",
                table: "Exams",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_SubjectObjId",
                table: "Exams",
                newName: "IX_Exams_SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Subjects_SubjectId",
                table: "Exams",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Subjects_SubjectId",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Exams",
                newName: "SubjectObjId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_SubjectId",
                table: "Exams",
                newName: "IX_Exams_SubjectObjId");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Subjects_SubjectObjId",
                table: "Exams",
                column: "SubjectObjId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
