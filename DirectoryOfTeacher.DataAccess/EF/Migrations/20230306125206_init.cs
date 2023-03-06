using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectoryOfTeacher.DataAccess.EF.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationalInstitution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherCharacteristics_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeacherCharacteristicDislikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherCharacteristicId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCharacteristicDislikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherCharacteristicDislikes_TeacherCharacteristics_TeacherCharacteristicId",
                        column: x => x.TeacherCharacteristicId,
                        principalTable: "TeacherCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCharacteristicLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherCharacteristicId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCharacteristicLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherCharacteristicLikes_TeacherCharacteristics_TeacherCharacteristicId",
                        column: x => x.TeacherCharacteristicId,
                        principalTable: "TeacherCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCharacteristicDislikes_TeacherCharacteristicId",
                table: "TeacherCharacteristicDislikes",
                column: "TeacherCharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCharacteristicLikes_TeacherCharacteristicId",
                table: "TeacherCharacteristicLikes",
                column: "TeacherCharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCharacteristics_TeacherId",
                table: "TeacherCharacteristics",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherCharacteristicDislikes");

            migrationBuilder.DropTable(
                name: "TeacherCharacteristicLikes");

            migrationBuilder.DropTable(
                name: "TeacherCharacteristics");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
