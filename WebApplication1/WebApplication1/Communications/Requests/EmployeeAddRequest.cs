using Newtonsoft.Json;

namespace Communications.Requests;

public class EmployeeAddRequest
{
    [JsonProperty("Id")] public int Id { get; set; }
    [JsonProperty("Name")] public string Name { get; set; }
    // [JsonProperty("Birthday")] public DateTime Birthday { get; set; }
    [JsonProperty("Gender")] public int Gender { get; set; }
    [JsonProperty("Role")] public string Role { get; set; }
}