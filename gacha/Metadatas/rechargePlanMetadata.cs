using System.ComponentModel.DataAnnotations;

namespace gacha.Matadatas
{
    public class rechargePlanMetadata
    {
        [Display(Name = "方案ID")]
        public int id { get; set; }

        [Display(Name = "方案名稱")]
        [Required(ErrorMessage = "方案名稱必填")]
        public string name { get; set; }

        [Display(Name = "詳細資料")]
        public string description { get; set; }

        [Display(Name = "點數")]
        [Required(ErrorMessage = "點數欄位必填")]
        public int point { get; set; }

        [Display(Name = "價錢")]
        [Required(ErrorMessage = "價錢欄位必填")]
        public int price { get; set; }

        [Display(Name = "啟用")]
        public bool status { get; set; }

        [Display(Name = "建立時間")]
        public DateTime? createdAt { get; set; }

        [Display(Name = "更新時間")]
        public DateTime? updatedAt { get; set; }
    }
}
