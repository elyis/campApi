using System.ComponentModel.DataAnnotations;
using campapi.src.Domain.Entities.Response;
using campapi.src.Domain.Enums;
using campApi.src.Domain.Entities.Response;
using Microsoft.EntityFrameworkCore;

namespace campapi.src.Domain.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Token), IsUnique = true)]
    public class UserModel
    {
        public Guid Id { get; set; }

        [StringLength(256, MinimumLength = 3)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string RoleName { get; set; }
        public string? Token { get; set; }
        public string? Image { get; set; }
        public string? Headquarters { get; set; }
        public string? Detachment { get; set; }
        public string? HeldPost { get; set; }
        public string? YearOfInitiation { get; set; }

        public string? CounselorCertificateFilename { get; set; }
        public string? MedicalBookFilename { get; set; }
        public string? VaccinationCertificateFilename { get; set; }
        public string? SanitaryMinimumFilename { get; set; }
        public string? CertificateOfNoCriminalRecordFilename { get; set; }
        public string? TrainingCertificateFilename { get; set; }



        public ProfileBody ToProfileBody()
        {
            return new ProfileBody
            {
                Email = Email,
                Role = Enum.Parse<UserRole>(RoleName),
                UrlIcon = string.IsNullOrEmpty(Image) ? null : $"{Constants.webPathToProfileIcons}{Image}",
                Detachment = Detachment,
                Headquarters = Headquarters,
                HeldPost = HeldPost,
                YearOfInitiation = YearOfInitiation,
                Documents = ToUserDocumentsBody()
            };
        }

        public UserDocumentsBody ToUserDocumentsBody()
        {
            return new UserDocumentsBody
            {
                CertificateOfNoCriminalRecordUri = string.IsNullOrEmpty(CertificateOfNoCriminalRecordFilename) ? null : $"{Constants.webPathToDocs}{CertificateOfNoCriminalRecordFilename}",
                CounselorCertificateUri = string.IsNullOrEmpty(CounselorCertificateFilename) ? null : $"{Constants.webPathToDocs}{CounselorCertificateFilename}",
                MedicalBookUri = string.IsNullOrEmpty(MedicalBookFilename) ? null : $"{Constants.webPathToDocs}{MedicalBookFilename}",
                SanitaryMinimumUri = string.IsNullOrEmpty(SanitaryMinimumFilename) ? null : $"{Constants.webPathToDocs}{SanitaryMinimumFilename}",
                TrainingCertificateUri = string.IsNullOrEmpty(TrainingCertificateFilename) ? null : $"{Constants.webPathToDocs}{TrainingCertificateFilename}",
                VaccinationCertificateUri = string.IsNullOrEmpty(VaccinationCertificateFilename) ? null : $"{Constants.webPathToDocs}{VaccinationCertificateFilename}",
            };
        }
    }
}