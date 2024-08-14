using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace gacha.ViewModels
{
    public class trackingList_ViewModel
    {
        [Display(Name = "會員ID")]
        public int UserId { get; set; }

        [Display(Name = "扭蛋機台ID")]
        public int GachaMachineId { get; set; }

        [Display(Name = " 追蹤日期")]
        public DateTime? TrackingDate { get; set; }

        [Display(Name = "通知狀態")]
        [Required (ErrorMessage=("通知狀態:待通知,無須通知,已通知"))]
        public string NoteStatus { get; set; }

        [Display(Name = "扭蛋機台名稱")]
        public string GachaMachineName { get; set; }

        [Display(Name = "電子郵件")]
        public string UserEmail { get; set; }

        [Display(Name = "會員名稱")]
        public string UserName { get; set; }
    }
}
