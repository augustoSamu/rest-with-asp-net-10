using rest_with_asp_net_10.JsonSerialization;
using System.Text.Json.Serialization;

namespace rest_with_asp_net_10.DTOs.V2
{
    public class PersonDTO
    {
        //[JsonPropertyOrder(3)]
        //[JsonPropertyName("code")]
        public int Id { get; set; }

        //[JsonPropertyOrder(4)]
        //[JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        //[JsonPropertyOrder(5)]
        //[JsonPropertyName("last_name")]
        public string LastName { get; set; }

        //[JsonPropertyOrder(1)]
        public string Address { get; set; }

        [JsonConverter(typeof(GenderSerializer))]
        public string Gender { get; set; }

        //[JsonPropertyOrder(2)]
        [JsonConverter(typeof(DateSerializer))]
        public DateTime? BirthDay { get; set; }
    }
}
