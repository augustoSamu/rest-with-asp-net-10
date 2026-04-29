using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace rest_with_asp_net_10.JsonSerialization
{
    public class DateSerializer : JsonConverter<DateTime?>
    {
        private readonly string _format = "dd/MM/yyyy";

        public override DateTime? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (DateTime.TryParseExact(reader.GetString(), _format, null, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
            return null;
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTime? value,
            JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteStringValue(value.Value.ToString(_format));
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}
