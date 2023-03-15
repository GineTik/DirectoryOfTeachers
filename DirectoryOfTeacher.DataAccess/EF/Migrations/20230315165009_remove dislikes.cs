using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectoryOfTeacher.DataAccess.EF.Migrations
{
    /// <inheritdoc />
    public partial class removedislikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCharacteristicDislikes_TeacherCharacteristics_TeacherCharacteristicId",
                table: "TeacherCharacteristicDislikes");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCharacteristics_Teachers_TeacherId",
                table: "TeacherCharacteristics");

            migrationBuilder.DropIndex(
                name: "IX_TeacherCharacteristicDislikes_TeacherCharacteristicId",
                table: "TeacherCharacteristicDislikes");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TeacherCharacteristics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "TeacherCharacteristicLikes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCharacteristics_Teachers_TeacherId",
                table: "TeacherCharacteristics",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCharacteristics_Teachers_TeacherId",
                table: "TeacherCharacteristics");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TeacherCharacteristics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TeacherCharacteristicLikes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCharacteristicDislikes_TeacherCharacteristicId",
                table: "TeacherCharacteristicDislikes",
                column: "TeacherCharacteristicId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCharacteristicDislikes_TeacherCharacteristics_TeacherCharacteristicId",
                table: "TeacherCharacteristicDislikes",
                column: "TeacherCharacteristicId",
                principalTable: "TeacherCharacteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCharacteristics_Teachers_TeacherId",
                table: "TeacherCharacteristics",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
