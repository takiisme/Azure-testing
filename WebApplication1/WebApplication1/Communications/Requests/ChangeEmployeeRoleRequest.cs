using Newtonsoft.Json;

namespace Communications.Requests
{
    public class ChangeEmployeeRoleRequest
    {
        [JsonProperty("Id")] public int Id { get; set; }
        [JsonProperty("Role")] public string Role { get; set; }
    }
}