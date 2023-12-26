namespace campApi.src.Domain.Entities.Response
{
    public class UserDocumentsBody
    {
        public string? CounselorCertificateUri { get; set; }
        public string? MedicalBookUri { get; set; }
        public string? VaccinationCertificateUri { get; set; }
        public string? SanitaryMinimumUri { get; set; }
        public string? CertificateOfNoCriminalRecordUri { get; set; }
        public string? TrainingCertificateUri { get; set; }
    }
}