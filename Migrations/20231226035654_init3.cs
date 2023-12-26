using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace campapi.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CertificateOfNoCriminalRecordFilename",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CounselorCertificateFilename",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalBookFilename",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanitaryMinimumFilename",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingCertificateFilename",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaccinationCertificateFilename",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CertificateOfNoCriminalRecordFilename",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CounselorCertificateFilename",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MedicalBookFilename",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SanitaryMinimumFilename",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrainingCertificateFilename",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VaccinationCertificateFilename",
                table: "Users");
        }
    }
}
