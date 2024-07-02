using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace gacha.ViewModels
{
    public class rechargeList_ViewModel
    {
        [Display(Name = "儲值紀錄ID")]
        public int id { get; set; }

        [Display(Name = "數量")]
        [Required(ErrorMessage = ("數量必填"))]
        public int quantity { get; set; }

        [Display(Name = "金額")]
        public int amount { get; set; }

        [Display(Name = "付款方式")]
        public string paymentMode { get; set; }

        [Display(Name = "儲值方案ID")]
        public int rechargePlanId { get; set; }

        [Display(Name = "會員ID")]
        public int userId { get; set; }
    }
}
