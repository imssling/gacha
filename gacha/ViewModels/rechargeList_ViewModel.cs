using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace gacha.ViewModels
{
    public class rechargeList_ViewModel
    {
        [Display(Name = "儲值紀錄ID")]
        public int id { get; set; }

        [Display(Name = "儲值方案ID")]
        [Required(ErrorMessage = ("儲值方案必填"))]
        public int rechargePlanId { get; set; }

        //[Display(Name = "儲值方案")]
        //public string? rechargePlan { get; set; }


        [Display(Name = "數量")]
        [Required(ErrorMessage = "數量必填")]
        [Range(1, 100, ErrorMessage = "數量必須在1到100之間")]
        public int quantity { get; set; }

        [Display(Name = "金額")]
        [Required(ErrorMessage = ("金額必填"))]
        public int amount { get; set; }

        [Display(Name = "付款方式")]
        [Required(ErrorMessage = ("付款方式必填"))]
        public string paymentMode { get; set; }

        [Display(Name = "會員ID")]
        [Required(ErrorMessage = ("會員ID必填"))]
        public int userId { get; set; }

        //[Display(Name = "會員名稱")]
        //public string userName { get; set; }
       
    }
}
