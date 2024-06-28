namespace gachaAPI.DTO
{
    public class ExchangeRecordDTO
    {
        public int Id { get; set; }
        public int? UserIdFrom { get; set; }
        public int? UserIdTo { get; set; }
        public int? GachaIdFrom { get; set; }
        public int? GachaIdTo { get; set; }
        public DateTime? ExchangeDate { get; set; }
    }
}