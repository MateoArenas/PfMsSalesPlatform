using System.Text.Json.Serialization;

namespace PfMsSalesPlatform.Application.DTOs
{
    public class UserDto
    {
        public string RegisterUser { get; set; }
        public string Passw{ get; set; }

        [JsonIgnore]
        public string? key { get; set; }
    }
}
