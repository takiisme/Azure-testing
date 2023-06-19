using Newtonsoft.Json;

namespace Communications.Requests
{
    public class GetEmployeeTaskRequest
    {
        [JsonProperty("Id")] public int Id { get; set; }
        [JsonProperty("StartDate")] public DateTime StartDate { get; set; }
        [JsonProperty("EndDate")] public DateTime EndDate { get; set; }
    }
}