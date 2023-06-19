using Newtonsoft.Json;

namespace Communications.Requests
{
    public class McpInRangeRequest
    {
        [JsonProperty("Latitude")] public string Latitude { get; set; }
        [JsonProperty("Longitude")] public string Longitude { get; set; }
        [JsonProperty("Radius")] public float Radius { get; set; }
    }
}