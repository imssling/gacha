namespace gachaAPI.DTO
{
    public class AchievementProgressDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public int Progress { get; set; }
        public int Target { get; set; }
    }
}