using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace campApi.src.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuestionType
    {
        Practical,
        Theoretical
    }
}