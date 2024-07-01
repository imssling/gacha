namespace gachaAPI.DTO
{
    public class AchievementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AchievementType { get; set; }
        public int Target { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}