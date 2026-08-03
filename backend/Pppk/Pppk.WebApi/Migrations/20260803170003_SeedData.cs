using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pppk.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "address_type",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Boravište" },
                    { 2, "Prebivalište" }
                });

            migrationBuilder.InsertData(
                table: "condition",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Hipertenzija" },
                    { 2, "Dijabetes tipa 2" },
                    { 3, "Astma" },
                    { 4, "Migrena" },
                    { 5, "Fibrilacija atrija" },
                    { 6, "Ekcem" },
                    { 7, "Gastritis" },
                    { 8, "Hipotireoza" }
                });

            migrationBuilder.InsertData(
                table: "examination_type",
                columns: new[] { "id", "code", "name" },
                values: new object[,]
                {
                    { 1, "CT", "Kompjuterizirana tomografija" },
                    { 2, "MR", "Magnetska rezonanca" },
                    { 3, "ULTRA", "Ultrazvuk" },
                    { 4, "EKG", "Elektrokardiogram" },
                    { 5, "ECHO", "Ehokardiogram" },
                    { 6, "OKO", "Pregled oka" },
                    { 7, "DERM", "Dermatološki pregled" },
                    { 8, "DENTA", "Stomatološki pregled" },
                    { 9, "MAMMO", "Mamografija" },
                    { 10, "EEG", "Elektroencefalogram" }
                });

            migrationBuilder.InsertData(
                table: "medication",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Lisinopril" },
                    { 2, "Metformin" },
                    { 3, "Salbutamol" },
                    { 4, "Sumatriptan" },
                    { 5, "Bisoprolol" },
                    { 6, "Hidrokortizon" },
                    { 7, "Omeprazol" },
                    { 8, "Levotiroksin" }
                });

            migrationBuilder.InsertData(
                table: "post",
                columns: new[] { "id", "city", "postal_code" },
                values: new object[,]
                {
                    { 1, "Zagreb", "10000" },
                    { 2, "Split", "21000" },
                    { 3, "Rijeka", "51000" },
                    { 4, "Osijek", "31000" },
                    { 5, "Zadar", "23000" },
                    { 6, "Sesvete", "10360" }
                });

            migrationBuilder.InsertData(
                table: "specialty",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Radiologija" },
                    { 2, "Kardiologija" },
                    { 3, "Oftalmologija" },
                    { 4, "Dermatologija" },
                    { 5, "Dentalna medicina" },
                    { 6, "Neurologija" }
                });

            migrationBuilder.InsertData(
                table: "doctor",
                columns: new[] { "id", "first_name", "last_name", "specialty_id" },
                values: new object[,]
                {
                    { 1, "Ana", "Kovač", 1 },
                    { 2, "Marko", "Horvat", 2 },
                    { 3, "Ivana", "Novak", 3 },
                    { 4, "Petar", "Marić", 4 },
                    { 5, "Lucija", "Jurić", 5 },
                    { 6, "Tomislav", "Babić", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_type_name",
                table: "address_type",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_address_type_name",
                table: "address_type");

            migrationBuilder.DeleteData(
                table: "address_type",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "address_type",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "condition",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "condition",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "condition",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "condition",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "condition",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "condition",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "condition",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "condition",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "doctor",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "doctor",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "doctor",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "doctor",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "doctor",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "doctor",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "examination_type",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "examination_type",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "examination_type",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "examination_type",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "examination_type",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "examination_type",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "examination_type",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "examination_type",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "examination_type",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "examination_type",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "medication",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "medication",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "medication",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "medication",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "medication",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "medication",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "medication",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "medication",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "post",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "post",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "post",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "post",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "post",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "post",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "specialty",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "specialty",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "specialty",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "specialty",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "specialty",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "specialty",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
