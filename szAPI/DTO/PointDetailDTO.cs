namespace szAPI.DTO
{
    public class PointDetailDTO
    {
        public int PointListId { get; set; }
        public int PointsChanged { get; set; }
        public int TotalPoints { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangeType { get; set; }
    }
}