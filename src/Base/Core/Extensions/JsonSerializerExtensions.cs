using System.Text.Encodings.Web;
using System.Text.Json;

namespace Core.Extensions
{
    public static class JsonSerializerExtensions
    {
        private static JsonSerializerOptions _jsonSerializerOptions;
        public static void Configure()
        {
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                IncludeFields = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
        }
        public static string SerializeCore<T>(T Model)
        {
            return JsonSerializer.Serialize(Model, _jsonSerializerOptions);
        }
        public static T DeserializeCore<T>(string Model)
        {
            return JsonSerializer.Deserialize<T>(Model);
        }
    }
}
