using System.ComponentModel.DataAnnotations;

namespace gacha.ViewModels
{
    public class activity_ViewModel
    {
        [Display(Name = "活動ID")]
        public int id { get; set; }

        [Display(Name = "標題")]
        public string title { get; set; }

        [Display(Name = "描述")]
        public string description { get; set; }

        [Display(Name = "狀態")]
        public bool status { get; set; }

        [Display(Name = "活動類型ID")]
        public int activityTypeId { get; set; }

        [Display(Name = "活動創建日")]
        public DateTime? createdAt { get; set; }

        [Display(Name = "活動開始日")]
        public DateTime? activityStart { get; set; }

        [Display(Name = "活動截止日")]
        public DateTime? activityEnd { get; set; }
    }
}
