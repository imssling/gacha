namespace gachaAPI.DTO
{
    public class UserAchievementDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public DateTime? AchievedAt { get; set; }
    }
}