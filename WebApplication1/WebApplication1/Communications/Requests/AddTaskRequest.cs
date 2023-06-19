using Newtonsoft.Json;

namespace Communications.Requests
{
    public class AddTaskRequest
    {
        [JsonProperty("Id")] public int Id { get; set; }
        [JsonProperty("Date")] public DateTime Date { get; set; }
        [JsonProperty("WorkerId")] public int WorkerId { get; set; }
    }
}