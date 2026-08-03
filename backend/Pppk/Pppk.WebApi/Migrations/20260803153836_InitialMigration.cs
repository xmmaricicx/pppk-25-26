using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Pppk.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "condition",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_condition", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "examination_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_examination_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medication",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medication", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    oib = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    postal_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "specialty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialty", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medical_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    condition_id = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_medical_history_condition_condition_id",
                        column: x => x.condition_id,
                        principalTable: "condition",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medical_history_patient_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prescription",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    medication_id = table.Column<int>(type: "integer", nullable: false),
                    condition_id = table.Column<int>(type: "integer", nullable: false),
                    dosage = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    frequency = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription", x => x.id);
                    table.ForeignKey(
                        name: "FK_prescription_condition_condition_id",
                        column: x => x.condition_id,
                        principalTable: "condition",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_prescription_medication_medication_id",
                        column: x => x.medication_id,
                        principalTable: "medication",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_prescription_patient_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    house_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    postal_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    post_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_post_post_id",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    specialty_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.id);
                    table.ForeignKey(
                        name: "FK_doctor_specialty_specialty_id",
                        column: x => x.specialty_id,
                        principalTable: "specialty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "specialty_examination_type",
                columns: table => new
                {
                    specialty_id = table.Column<int>(type: "integer", nullable: false),
                    examination_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialty_examination_type", x => new { x.specialty_id, x.examination_type_id });
                    table.ForeignKey(
                        name: "FK_specialty_examination_type_examination_type_examination_typ~",
                        column: x => x.examination_type_id,
                        principalTable: "examination_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_specialty_examination_type_specialty_specialty_id",
                        column: x => x.specialty_id,
                        principalTable: "specialty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patient_address",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    address_type_id = table.Column<int>(type: "integer", nullable: false),
                    address_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_patient_address_address_address_id",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_patient_address_address_type_address_type_id",
                        column: x => x.address_type_id,
                        principalTable: "address_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_patient_address_patient_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    examination_type_id = table.Column<int>(type: "integer", nullable: false),
                    scheduled_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointment_doctor_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointment_examination_type_examination_type_id",
                        column: x => x.examination_type_id,
                        principalTable: "examination_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointment_patient_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_post_id",
                table: "address",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_doctor_id_scheduled_at",
                table: "appointment",
                columns: new[] { "doctor_id", "scheduled_at" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointment_examination_type_id",
                table: "appointment",
                column: "examination_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_patient_id_scheduled_at",
                table: "appointment",
                columns: new[] { "patient_id", "scheduled_at" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_doctor_specialty_id",
                table: "doctor",
                column: "specialty_id");

            migrationBuilder.CreateIndex(
                name: "IX_examination_type_code",
                table: "examination_type",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_medical_history_condition_id",
                table: "medical_history",
                column: "condition_id");

            migrationBuilder.CreateIndex(
                name: "IX_medical_history_patient_id_condition_id_start_date",
                table: "medical_history",
                columns: new[] { "patient_id", "condition_id", "start_date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patient_oib",
                table: "patient",
                column: "oib",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patient_address_address_id",
                table: "patient_address",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_address_address_type_id",
                table: "patient_address",
                column: "address_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_address_patient_id_address_type_id",
                table: "patient_address",
                columns: new[] { "patient_id", "address_type_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_post_postal_code",
                table: "post",
                column: "postal_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prescription_condition_id",
                table: "prescription",
                column: "condition_id");

            migrationBuilder.CreateIndex(
                name: "IX_prescription_medication_id",
                table: "prescription",
                column: "medication_id");

            migrationBuilder.CreateIndex(
                name: "IX_prescription_patient_id_medication_id_condition_id",
                table: "prescription",
                columns: new[] { "patient_id", "medication_id", "condition_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_specialty_name",
                table: "specialty",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_specialty_examination_type_examination_type_id",
                table: "specialty_examination_type",
                column: "examination_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "medical_history");

            migrationBuilder.DropTable(
                name: "patient_address");

            migrationBuilder.DropTable(
                name: "prescription");

            migrationBuilder.DropTable(
                name: "specialty_examination_type");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "address_type");

            migrationBuilder.DropTable(
                name: "condition");

            migrationBuilder.DropTable(
                name: "medication");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "examination_type");

            migrationBuilder.DropTable(
                name: "specialty");

            migrationBuilder.DropTable(
                name: "post");
        }
    }
}
