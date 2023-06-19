using Newtonsoft.Json;

namespace Communications.Requests
{
    public class UpdateMessageRequest
    {
        [JsonProperty("Id")] public int Id { get; set; }
        [JsonProperty("TextContent")] public string TextContent { get; set; }
    }
}