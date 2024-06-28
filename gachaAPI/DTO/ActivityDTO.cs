using gachaAPI.Models;

namespace gachaAPI.DTO
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int ActivityTypeId { get; set; }
        public DateTime? ActivityStart { get; set; }
        public DateTime? ActivityEnd { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}