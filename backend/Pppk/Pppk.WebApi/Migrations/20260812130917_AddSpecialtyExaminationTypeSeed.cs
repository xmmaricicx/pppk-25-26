using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pppk.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecialtyExaminationTypeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "specialty_examination_type",
                columns: new[] { "examination_type_id", "specialty_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 9, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 3 },
                    { 7, 4 },
                    { 8, 5 },
                    { 10, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "specialty_examination_type",
                keyColumns: new[] { "examination_type_id", "specialty_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "specialty_examination_type",
                keyColumns: new[] { "examination_type_id", "specialty_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "specialty_examination_type",
                keyColumns: new[] { "examination_type_id", "specialty_id" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "specialty_examination_type",
                keyColumns: new[] { "examination_type_id", "specialty_id" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "specialty_examination_type",
                keyColumns: new[] { "examination_type_id", "specialty_id" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "specialty_examination_type",
                keyColumns: new[] { "examination_type_id", "specialty_id" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "specialty_examination_type",
                keyColumns: new[] { "examination_type_id", "specialty_id" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "specialty_examination_type",
                keyColumns: new[] { "examination_type_id", "specialty_id" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "specialty_examination_type",
                keyColumns: new[] { "examination_type_id", "specialty_id" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "specialty_examination_type",
                keyColumns: new[] { "examination_type_id", "specialty_id" },
                keyValues: new object[] { 10, 6 });
        }
    }
}
