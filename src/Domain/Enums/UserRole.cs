using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace campapi.src.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserRole
    {
        Beginner, 
        Candidate, 
        Fighter, 
        OldMan, 
        Veteran
    }
}