namespace szAPI.DTO
{
    public class GachaDetailListDTO
    {
        public int id { get; set; }
        public string? gachaProductName { get; set; }
        public string? status { get; set; }
        public int quantity { get; set; }
        public DateTime updateTime { get; set; }
    }
}