using Newtonsoft.Json;

namespace Communications.Requests;

public class McpAddRequest
{
    [JsonProperty("Id")] public int Id { get; set; }
    [JsonProperty("Longitude")] public string Longitude { get; set; }
    [JsonProperty("Latitude")] public string Latitude { get; set; }
}