using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace campApi.src.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserDocuments
    {
        CounselorCertificate,
        MedicalBook,
        VaccinationCertificate,
        SanitaryMinimum,
        CertificateOfNoCriminalRecord,
        TrainingCertificate,
    }
}