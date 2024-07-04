using System.ComponentModel.DataAnnotations;

namespace gacha.ViewModels
{
    public class exchangeRecord_ViewModel
    {
        [Display(Name = "交換紀錄ID")]  
        public int id { get; set; }

        [Display(Name = "發起交換用戶")]
        public string? UserName { get; set; }

        [Display(Name = "接受交換用戶")]
        public string? UserNameTo { get; set; }

        [Display(Name = "發起交換用戶的扭蛋")]
        public string? GachaNameFrom { get; set; }

        [Display(Name = "接受交換用戶的扭蛋")]
        public string? GachaNameTo { get; set; }

        [Display(Name = "創建時間")]
        public DateTime? ExchangeDate { get; set; }
    }
}
