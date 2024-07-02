using System.Text.Json.Serialization;

namespace szAPI.DTO
{
    public class BagDTO
    {
        public int id { get; set; }
        public int gachaProductId { get; set; }
        //[JsonIgnore] 不傳回userId
        public int userId { get; set; }
        public string? productName { get; set; }
        public string? machineName { get; set; }
        public string? themeName { get; set; }
        public string? gachaStatus { get; set; }
        public DateTime date { get; set; }
    }
}