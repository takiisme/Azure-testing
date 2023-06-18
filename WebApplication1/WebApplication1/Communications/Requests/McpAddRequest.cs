using Newtonsoft.Json;

namespace Communications.Requests;

public class McpAddRequest
{
    [JsonProperty("Id")] public int Id { get; set; }
    [JsonProperty("Capacity")] public int Capacity { get; set; }
    [JsonProperty("CurrentLoad")] public int CurrentLoad { get; set; }
    [JsonProperty("Longitude")] public string Longitude { get; set; }
    [JsonProperty("Latitude")] public string Latitude { get; set; }
}