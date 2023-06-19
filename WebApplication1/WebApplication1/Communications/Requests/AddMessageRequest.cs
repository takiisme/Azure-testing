using System.Runtime.InteropServices.JavaScript;
using Models;
using Newtonsoft.Json;

namespace Communications.Requests
{
    public class AddMessageRequest
    {
        [JsonProperty("Id")] public int Id { get; set; }
        [JsonProperty("SenderId")] public int Sender { get; set; }
        [JsonProperty("ReceiverId")] public int Receiver { get; set; }
        [JsonProperty("TextTime")] public DateTime TextTime { get; set; }
        [JsonProperty("TextContent")] public string TextContent { get; set; }
    }
}