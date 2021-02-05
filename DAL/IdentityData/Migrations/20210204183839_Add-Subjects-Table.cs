using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.IdentityData.Migrations
{
    public partial class AddSubjectsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectObjId",
                table: "Exams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SubjectObjId",
                table: "Exams",
                column: "SubjectObjId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Subjects_SubjectObjId",
                table: "Exams",
                column: "SubjectObjId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Subjects_SubjectObjId",
                table: "Exams");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Exams_SubjectObjId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "SubjectObjId",
                table: "Exams");
        }
    }
}
