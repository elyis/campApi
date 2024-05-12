using campapi.src.Domain.Enums;
using campApi.src.Domain.Entities.Response;

namespace campapi.src.Domain.Entities.Response
{
    public class ProfileBody
    {
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string? UrlIcon { get; set; }
        public string? Headquarters { get; set; }
        public string? Detachment { get; set; }
        public string? HeldPost { get; set; }
        public string? YearOfInitiation { get; set; }

        public UserDocumentsBody Documents { get; set; }
    }
}