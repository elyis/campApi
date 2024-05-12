using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace campApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Answers = table.Column<string>(type: "text", nullable: false),
                    RightAnswerIndex = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Headquarters = table.Column<string>(type: "text", nullable: true),
                    Detachment = table.Column<string>(type: "text", nullable: true),
                    HeldPost = table.Column<string>(type: "text", nullable: true),
                    YearOfInitiation = table.Column<string>(type: "text", nullable: true),
                    CounselorCertificateFilename = table.Column<string>(type: "text", nullable: true),
                    MedicalBookFilename = table.Column<string>(type: "text", nullable: true),
                    VaccinationCertificateFilename = table.Column<string>(type: "text", nullable: true),
                    SanitaryMinimumFilename = table.Column<string>(type: "text", nullable: true),
                    CertificateOfNoCriminalRecordFilename = table.Column<string>(type: "text", nullable: true),
                    TrainingCertificateFilename = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Token",
                table: "Users",
                column: "Token",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
